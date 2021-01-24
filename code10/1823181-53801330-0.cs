    public class Person
    {
        // this is your default constructor
        public Person()
        {
        }
        // this is your copy constructor
        public Person(Person originalPerson)
        {
            Name = originalPerson.Name;
            Surname = originalPerson.Surname;
            Address = originalPerson.Address;
            Age = originalPerson.Age;
        }
        public string Name;
        public string Surname;
        public string Address;
        public int Age;
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // create object with whatever properties you like
            var person1 = new Person
            {
                Name = "Max",
                Surname = "Mustermann",
            };
            
            // now rewrite the old object with the old properties and modify
            // any properties you like using object initialization
            person1 = new Person(person1)
            {
                Address = "Main Street 1",
                Age = 32,
            };
        }
    }
