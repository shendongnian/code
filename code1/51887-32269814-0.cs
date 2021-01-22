        class Person
        {
            public int Age;
        }
    
        class Program
        {
            private static void Main(string[] args)
            {
                var persons = new List<Person>(new[] {new Person {Age = 20}, new Person {Age = 22}});
                PrintPersons(persons);
    
                //this doesn't work:
                persons.Select(p =>
                {
                    p.Age++;
                    return p;
                });
                PrintPersons(persons);
    
                //with "ToList" it works
                persons.Select(p =>
                {
                    p.Age++;
                    return p;
                }).ToList();
                PrintPersons(persons);
    
                //This is the best solution
                persons.ForEach(p =>
                {
                    p.Age++;
                });
                PrintPersons(persons);
                Console.ReadLine();
            }
    
            private static void PrintPersons(List<Person> persons)
            {
                Console.WriteLine("================");
                foreach (var person in persons)
                {
                    Console.WriteLine("Age: {0}", person.Age);
                ;
                }
            }
        }
