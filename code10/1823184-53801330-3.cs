    public class Person
    {
        public Person() // this is your default constructor
        {
        }
        public Person(Person originalPerson) // this is your copy constructor
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
                Name = "Max", Surname = "Mustermann", Age = 30,
            };
            
            // now rewrite the old object with the old properties and modify
            // any properties you like using object initialization
            person1 = new Person(person1)
            {
                Address = "Main Street 1",
                Age = 32,
            };
            // now person1 has the Name, Surname from 1st assignment
            // plus Address and Age from 2nd assignment (Age = 32)
        }
    }
