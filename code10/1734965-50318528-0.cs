    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Question_Answer_Console_App
    {
        public class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                var people = new List<Person>()
                {
                    new Person() { Name = "Mathew", Password = "2345" },
                    new Person() { Name = "Mathew", Password = "1234" },
                    new Person() { Name = "John", Password = "5678" },
                    new Person() { Name = "Mark", Password = "5678" },
                    new Person() { Name = "Luke", Password = "0987" },
                    new Person() { Name = "John", Password = "6534" }
                };
    
                var names = people.OrderBy(person => person.Name).Select(person => person.Name).ToList();
                var passwords = people.OrderBy(person => person.Password).Select(person => person.Password).ToList();
                var sortPeople = new List<Person>();
                for (int i = 0; i < names.Count(); i++) sortPeople.Add(new Person() { Name = names[i], Password = passwords[i] });  
                foreach (var person in sortPeople) Console.WriteLine($"{person.Name} : {person.Password}");
                Console.Read();
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public string Password { get; set; }
        }
    }
