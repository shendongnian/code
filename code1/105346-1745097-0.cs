    using System;
    using System.Reflection;
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    class Test    
    {
        static void Main()
        {
            Person jon = new Person { Name = "Jon", Age = 33 };
            ShowProperty(jon, "Name");
            ShowProperty(jon, "Age");
        }
        
        static void ShowProperty(object target, string propertyName)
        {
            // We don't need no stinkin' error handling or validity
            // checking (but you do if you want production code)
            PropertyInfo property = target.GetType().GetProperty(propertyName);
            object value = property.GetValue(target, null);
            Console.WriteLine(value);
        }
    }
