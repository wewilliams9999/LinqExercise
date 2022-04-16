using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printed with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers
            var sum = numbers.Sum();
            var average = numbers.Average();
            Console.WriteLine($"Sum: {sum}.  Average: {average}");

            //Order numbers in ascending order and descending order. Print each to console.
            var ascend = numbers.OrderBy(num => num);
            Console.WriteLine("Ascending:");
            
            foreach (var num in ascend)
            {
                Console.WriteLine(num);
            }

            var descend = numbers.OrderByDescending(num => num);
            Console.WriteLine("Descending:");
            foreach (var num in descend)
            {
                Console.WriteLine(num);
            }


            //Print to the console only the numbers greater than 6
            var gtrThan6 = numbers.Where(num => num > 6);
            Console.WriteLine("These numbers are greater than 6:");
            foreach (var num in gtrThan6)
            {
                Console.WriteLine(num);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Below are the first 4 numbers:");
            foreach (var num in ascend.Take(4))
            {
                Console.WriteLine(num);
            }

            //Change value at index 4 to your age
                //then print the numbers in descending order
            Console.WriteLine("Below are the #s in desc order after I replaced 1 # with my age:");
            numbers[4] = 36;
            foreach (var num in numbers.OrderByDescending(num => num))
            {
                Console.WriteLine(num);
            }


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.
            var FullNameIfCorS = 
                employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'))
                .OrderBy(person => person.FirstName);

            Console.WriteLine("C or S Employees:");
            foreach (var employee in FullNameIfCorS)
            {
                Console.WriteLine(employee.FullName);
            }

            //Print all employees' FullName and Age who are over age 26 to console.
                //Order this by Age first and then by FirstName in the same result.
            var Over26 = employees.Where(person => person.Age > 26).
                       OrderBy(person => person.Age).ThenBy(person => person.FirstName);

            Console.WriteLine("Employees over 26:");
            foreach (var employee in Over26)
            {
                Console.WriteLine($"Name: {employee.FullName}.  Age: {employee.Age}.");
            }

            //Print Sum and then Average of employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var years = employees.Where(emp => emp.YearsOfExperience <= 10 && emp.Age > 35);

            Console.WriteLine($"Sum: {years.Sum(ppl => ppl.YearsOfExperience)}. Avg: {years.Average(ppl => ppl.YearsOfExperience)}.");


            //Add an employee to end of list without using employees.Add()
            employees = employees.Append(new Employee("George", "Glass", 98, 1)).ToList();
            
            foreach (var emp in employees)
            {
                Console.WriteLine($"First Name: {emp.FirstName} Last Name: {emp.LastName} Age: {emp.Age} YOE: {emp.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
