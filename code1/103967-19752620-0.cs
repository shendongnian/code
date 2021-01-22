    namespace Predicate
    {
        class Person
        {
            public int Age { get; set; }
        }
        class Program
        {
            static void Main(string[] args)
            {
                foreach (Person person in OlderThan(18))
                {
                    Console.WriteLine(person.Age);
                }
            }
    
            static IEnumerable<Person> OlderThan(int age)
            {
                Predicate<Person> isOld = x => x.Age > age;
                Person[] persons = { new Person { Age = 10 }, new Person { Age = 20 }, new Person { Age = 19 } };
    
                foreach (Person person in persons)
                    if (isOld(person)) yield return person;
            }
        }
    }
