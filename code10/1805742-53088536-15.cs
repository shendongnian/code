    using System;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person person = new Person() { Name = "Mathew" };
                Console.WriteLine(person.Name);
    
                person = new Employee(person) { Job = "Stocker" };
                Console.WriteLine(person.Name);
    
                person = new Customer(person) { IsShopping = true };            
                Console.WriteLine(person.Name);
    
                Console.ReadKey();
            }
            //OUTPUTS
            //Mathew
            //Employee, Mathew
            //Customer, Employee, Mathew
        }
    
        public class Person
        {
            public virtual string Name { get; set; } = "John Doe";
        }
    
        public class PersonDecorator : Person
        {
            protected Person Person { get; }
            public PersonDecorator(Person person) => Person = person;
            public override string Name => Person.Name;
        }
    
        public class Employee : PersonDecorator
        {
            public Employee(Person person = null) : base(person ?? new Person()) { }
            public override string Name => $"Employee, {base.Name}";
            public string Job { get; set; }
        }
    
        public class Customer : PersonDecorator
        {
            public Customer(Person person) : base(person ?? new Person()) { }
            public override string Name => $"Customer, {base.Name}";
            public bool IsShopping { get; set; }
        }
    }
