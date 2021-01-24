    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Problem
    {
        // Simple Model Class.
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        class Program
        {
            // Delegate.
            public delegate string PersonHandler(Person person);
            static void Main(string[] args)
            {
                List<Person> _persons = new List<Person>()
                {
                    new Person(){Id=1,Name="Joe"},
                    new Person(){Id=2,Name="James"},
                    new Person(){Id=3,Name="Nick"},
                    new Person(){Id=4,Name="Mike"},
                    new Person(){Id=5,Name="John"},
                };
    
                PersonHandler _personHandler = new PersonHandler(GetIdOfPerson);
    
                IEnumerable<string> _personIds = _persons.Select(p => _personHandler.Invoke(p));
    
                foreach (var id in _personIds)
                {
                    Console.WriteLine(string.Format("Id's : {0}", id));
                }
            }
    
    
            // This is the GetId Method.
            static string GetIdOfPerson(Person person)
            {
                string Id = person.Id.ToString();
                return Id;
            }
        }
    }
