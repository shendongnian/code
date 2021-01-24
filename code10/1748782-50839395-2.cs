    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Person
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Group);
        }
    }
    
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
        {
            while (source.Any())
            {
                yield return source.Take(chunksize);
                source = source.Skip(chunksize);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[] {
                    new Person() { Name = "person1", Group = "A" },
                    new Person() { Name = "person2", Group = "A" },
                    new Person() { Name = "person3", Group = "A" },
                    new Person() { Name = "person4", Group = "B" },
                    new Person() { Name = "person5", Group = "B" },
                    new Person() { Name = "person6", Group = "B" }
                };
    
            var query = people.GroupBy(person => person.Group)
                .SelectMany(g => g.Chunk(2))
                .SelectMany(g => g.GroupBy(person => person.Group));
    
            foreach (var group in query)
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                {
                    Console.WriteLine("   {0}", item);
                }
            }
        }
    }
