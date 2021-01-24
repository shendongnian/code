    using System;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPerson iPerson = new Person() { Name = "Mathew" };
                Person person = new Person() { Name = "Mark" };
                Person employeePerson = new Employee() { Name = "Luke" };
                IPerson iEmployeePerson = new Employee() { Name = "John" };
                IEmployee iEmployee = new Employee() { Name = "Acts" }; //pay attention to this!!            
                Employee employee = new Employee() { Name = "Romans" };
    
                Console.WriteLine(iPerson.Name);
                Console.WriteLine(person.Name);
                Console.WriteLine(employeePerson.Name);
                Console.WriteLine(iEmployeePerson.Name);
                Console.WriteLine(iEmployee.Name);
                iEmployee.Name = "Corinthians"; //And pay attention to this!!
                Console.WriteLine(iEmployee.Name);
                Console.WriteLine(employee.Name);
    
                Console.ReadKey();
            }
        }
    
        public interface IPerson
        {
            string Name { get; set; }
        }
    
        public interface IEmployee
        {
            string Name { get; set; }
        }
    
        public class Person : IPerson
        {
            public string Name { get; set; } = "No Name";
        }
    
        public class Employee : Person, IEmployee
        {
            public string Address { get; set; }
            string IEmployee.Name { get; set; } //And pay attention to this!! (Explicit interface declaration)
        }
        //Output
        //Mathew
        //Mark
        //Luke
        //John
        
        //Corinthians
        //Romans
    }
