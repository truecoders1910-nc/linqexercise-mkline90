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

            //Print the Sum and Average of numbers - COMPLETED

            var numberSum = numbers.Sum();
            var numberAverage = numbers.Average();
            Console.WriteLine($"The sum from numbers is: {numberSum}");
            Console.WriteLine($"The average from numbers is: {numberAverage}");


            ////Order numbers in ascending order and decsending order. Print each to console. - COMPLETED

            var numberAscend = from number in numbers
                               orderby number ascending
                               select number;

            foreach (var n in numberAscend)
            {
                Console.WriteLine(n);
            }

            var numberDescend = from number in numbers
                                orderby number descending
                                select number;

            foreach (var n in numberDescend)
            {
                Console.WriteLine(n);
            }

            ////Print to the console only the numbers greater than 6 - COMPLETED

            IEnumerable<int> numbersGreater =
                from number in numbers
                where number > 6
                orderby number ascending
                select number;

            foreach (int numAbove in numbersGreater)
            {
                Console.WriteLine(numAbove);
            }

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!** - COMPLETED

            IEnumerable<int> Values =
                from val in numbers
                where val < 4
                orderby val descending
                select val;

            foreach (int val in Values)
            {
                Console.WriteLine(val);
            }



            ////Change the value at index 4 to your age, then print the numbers in decsending order - COMPLETED

            numbers.SetValue(29, 4);
            var myAge = from number in numbers
                        orderby number descending
                        select number;
            foreach (var n in myAge)
            {
                Console.WriteLine(n);
            }



            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var FirstNames = employees.OrderBy(x => x.FirstName).Where(names =>
            employees.Any(name => names.FirstName.StartsWith("S") || names.FirstName.StartsWith("C")));


            foreach (var person in FirstNames)
            {
                Console.WriteLine(person.FullName);
            }


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.


            var NameAge = employees.OrderBy(x => x.Age).ThenBy(x => x.FullName).Where(AgeName => employees.Any(ageNames => AgeName.Age > 26));
            foreach (var item in NameAge)
            {
                Console.WriteLine(item.Age + " " + item.FullName);
            }




            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Sum(x => x.YearsOfExperience));

            Console.WriteLine(employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35).Average(x => x.YearsOfExperience));





            //Add an employee to the end of the list without using employees.Add()

            Employee emp = new Employee("Michael", "Kline", 29, 1);
            var newEmployees = employees.Append(emp).ToList();
            foreach (var item in newEmployees)
            {
                Console.WriteLine($"{item.FullName},{item.Age},{item.YearsOfExperience}");
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



