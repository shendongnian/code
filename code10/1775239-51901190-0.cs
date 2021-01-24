    using System;
    using System.Reflection;
    
    class Base
    {
        private int x = 10;    
    }
    
    class Derived : Base
    {
        private int y = 20;
    }
    
    class Program
    {
        static void Main()
        {
            var instance = new Derived();
            var type = instance.GetType();
            while (type != null)
            {
                Console.WriteLine($"Fields in {type}:");
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                foreach (var field in fields);
                {
                    Console.WriteLine($"{field.Name}: {field.GetValue(instance)}");
                }
                type = type.BaseType;
            }
        }
    }
