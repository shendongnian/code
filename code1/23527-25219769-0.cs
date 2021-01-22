    public class Program
    {
            public static void Main(string[] args)
            {
                var person1 = BuildPerson();
    
                Console.WriteLine(person1.Firstname);
                Console.WriteLine(person1.Lastname);
                Console.WriteLine(person1.BirthDate);
                Console.WriteLine(person1.Height);
    
                var person2 = BuildPerson(p =>
                {
                    p.Firstname = "Jane";
                    p.BirthDate = DateTime.Today;
                    p.Height = 1.76;
                });
    
                Console.WriteLine(person2.Firstname);
                Console.WriteLine(person2.Lastname);
                Console.WriteLine(person2.BirthDate);
                Console.WriteLine(person2.Height);
    
                Console.Read();
            }
    
            public static Person BuildPerson(Action<Person> overrideAction = null)
            {
                var person = new Person()
                {
                    Firstname = "John",
                    Lastname = "Doe",
                    BirthDate = new DateTime(2012, 2, 2)
                };
    
                if (overrideAction != null)
                    overrideAction(person);
    
                return person;
            }
        }
    
        public class Person
        {
            public string Firstname { get; set; }
            public string Lastname { get; set; }
            public DateTime BirthDate { get; set; }
            public double Height { get; set; }
        }
