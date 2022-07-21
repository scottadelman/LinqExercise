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
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers

            Console.WriteLine(numbers.Sum());

            //TODO: Print the Average of numbers

            Console.WriteLine(numbers.Average());

            //TODO: Order numbers in ascending order and print to the console

            var ascendingOrder = numbers.OrderBy(item => item);
            foreach (var number in ascendingOrder)
            {
                Console.WriteLine($"Numbers in acending order: {number}");
            }

            //TODO: Order numbers in decsending order adn print to the console

            var descendingOrder = numbers.OrderByDescending(item => item);
            foreach (var number in descendingOrder)
            {
                Console.WriteLine($"Numbers in decending order: {number}");
            }

            //TODO: Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(num => num > 6);
            foreach(var number in greaterThanSix)
            {
                Console.WriteLine($"Numbers less than 6: {number}");
            }

            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            foreach (var number in descendingOrder.Take(4))
            {
                Console.WriteLine(number);
            }

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order

            numbers.SetValue(24, 4);
            var descendingWithAge = numbers.OrderByDescending(number => number);
            foreach (var number in descendingWithAge)
            {
                Console.WriteLine();
            }

            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in acesnding order by FirstName.

            var filtered = employees.Where(person => person.FirstName.ToLower().StartsWith('c') || person.FirstName.ToLower().StartsWith('s')).OrderBy(person => person.FirstName);
            foreach(var person in filtered)
            {
                Console.WriteLine($"People whose name starts with C or S: {person.FullName}");
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var overTwentySix = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).ThenBy(x => x.FirstName);
            foreach(var item in overTwentySix)
            {
                Console.WriteLine($"Name: {item.FullName}, Age: {item.Age}");
            }

            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35

            var sumAndYOE = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine($"Total Years Of Experience: {sumAndYOE.Sum(x => x.YearsOfExperience)}");
            Console.WriteLine($"Average Years Of Expereience: {sumAndYOE.Average(x => x.YearsOfExperience)}");

            //TODO: Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Scott", "Adelman", 24, 2)).ToList();
            foreach(var item in employees)
            {
                Console.WriteLine(item.FirstName, item.LastName, item.Age, item.YearsOfExperience);
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
