    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization.Formatters.Binary;
    
    public static class Extensions
    {
        // Returns a string unique(TM) to this object.
        public static string Idem<T>(this T toSerialize)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var memoryStream = new MemoryStream();
            using (memoryStream)
            {
                formatter.Serialize(memoryStream, toSerialize);
                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }
    
    [Serializable()]
    public class Person
    {
        public Person(string name, string secret)
        {
            this.name = name;
            this.secret = secret;
        }
    
        private string secret; // some private info
        public string Nickname { get { return name; } } // some property
        public string name; // some public info
    
        public override string ToString() // a way to see the private info for this demo
        {
            return string.Format("{0} ({1})", name, secret);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // You can rearrange the items in this list and they will always come out in the same order.
            List<Person> myList = new List<Person>() {
                new Person("Bob", "alpha"),
                new Person("Bob", "bravo"),
                new Person("Alice", "delta"),
                new Person("Bob", "echo"),
                new Person("Bob", "golf"),
                new Person("Bob", "foxtrot"),
            };
            PropertyInfo sortProperty = typeof(Person).GetProperty("Nickname");
    
            Random random = new Random();
            for (int i = 0; i < 3; ++i)
            {
                var randomList = myList.OrderBy(x => random.Next());
    
                
                var sortedList = randomList.OrderBy(x => sortProperty.GetValue(x))
                    .ThenBy(x => x.Idem()); // Here's the magic "Then By Idem" clause.
    
                Console.WriteLine(string.Join(Environment.NewLine, sortedList));
                Console.WriteLine();
            }
        }
    }
