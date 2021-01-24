    using System;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person person = new Person() { Name = "Mathew" };
                Person employeePerson = new Employee() { Name = "Mark" };
                Person castedEmployee = new Employee() { Name = "Luke" };
                Employee employee = new Employee() { Name = "John" };
                //Compile error -> Employee personEmployee = new Person() { Name = "Acts" };    
    
                Console.WriteLine(person.Name);
                Console.WriteLine(employeePerson.Name); //Referenced Employee but got Person
                Console.WriteLine(((Employee)castedEmployee).Name); //Notice we cast here
                Console.WriteLine(employee.Name);
    
                Console.ReadKey();
            }
        }
    
        public class Person
        {
            public string Name { get; set; } = "No Name";
        }
    
        public class Employee : Person
        {
            new public string Name { get; set; }
            public string Address { get; set; }
        }
        //Output
        //Mathew
        //No Name
        //Luke
        //John
    }
