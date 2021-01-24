    using System;
    namespace Demo
    {
        public sealed class Person
        {
            public Person(string name)
            {
                Name = name;
            }
            public static implicit operator Person(string name)
            {
                return new Person(name);
            }
            public string Name { get; }
        }
        static class Program
        {
            static void Main()
            {
                Person person = "Fred";
                Console.WriteLine(person.Name);
            }
        }
    }
