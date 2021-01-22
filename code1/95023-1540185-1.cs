    // This doesn't work, but it would if collection initializers checked
    // extension methods.
    using System;
    using System.Collections.Generic;
    
    public class ChildObject
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    public static class Extensions
    {
        public static void Add(this List<ChildObject> children, 
                               string name, int age)
        {
            children.Add(new ChildObject { Name = name, Age = age });
        }
    }
    
    class Test
    {
        static void Main(string[] args)
        {
            List<ChildObject> children = new List<ChildObject>
            {
                { "Sylvester", 8 },
                { "Whiskers", 2 },
                { "Sasha", 14 }
            };
        }
    }
