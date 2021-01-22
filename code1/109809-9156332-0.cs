    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    class Program
    {
        class NameComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, true);
            }
        }
    
        class Person
        {
            public Person(string id, string name)
            {
                Id = id;
                Name = name;
            }
            public string Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Id + ": " + Name;
            }
        }
    
        private static Random randomSeed = new Random();
        public static string RandomString(int size, bool lowerCase)
        {
            var sb = new StringBuilder(size);
            int start = (lowerCase) ? 97 : 65;
            for (int i = 0; i < size; i++)
            {
                sb.Append((char)(26 * randomSeed.NextDouble() + start));
            }
            return sb.ToString();
        }
    
        private class PersonList : List<Person>
        {
            public PersonList(IEnumerable<Person> persons)
               : base(persons)
            {
            }
    
            public PersonList()
            {
            }
    
            public override string ToString()
            {
                var names = Math.Min(Count, 5);
                var builder = new StringBuilder();
                for (var i = 0; i < names; i++)
                    builder.Append(this[i]).Append(", ");
                return builder.ToString();
            }
        }
    
        static void Main()
        {
            var persons = new PersonList();
            for (int i = 0; i < 100000; i++)
            {
                persons.Add(new Person("P" + i.ToString(), RandomString(5, true)));
            } 
    
            var unsortedPersons = new PersonList(persons);
    
            const int COUNT = 30;
            Stopwatch watch = new Stopwatch();
            for (int i = 0; i < COUNT; i++)
            {
                watch.Start();
                Sort(persons);
                watch.Stop();
                persons.Clear();
                persons.AddRange(unsortedPersons);
            }
            Console.WriteLine("Sort: {0}ms", watch.ElapsedMilliseconds);
    
            watch = new Stopwatch();
            for (int i = 0; i < COUNT; i++)
            {
                watch.Start();
                OrderBy(persons);
                watch.Stop();
                persons.Clear();
                persons.AddRange(unsortedPersons);
            }
            Console.WriteLine("OrderBy: {0}ms", watch.ElapsedMilliseconds);
    
            watch = new Stopwatch();
            for (int i = 0; i < COUNT; i++)
            {
                watch.Start();
                OrderByWithToList(persons);
                watch.Stop();
                persons.Clear();
                persons.AddRange(unsortedPersons);
            }
            Console.WriteLine("OrderByWithToList: {0}ms", watch.ElapsedMilliseconds);
        }
    
        static void Sort(List<Person> list)
        {
            list.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, true));
        }
    
        static void OrderBy(List<Person> list)
        {
            var result = list.OrderBy(n => n.Name, new NameComparer()).ToArray();
        }
    
        static void OrderByWithToList(List<Person> list)
        {
            var result = list.OrderBy(n => n.Name, new NameComparer()).ToList();
        }
    }
