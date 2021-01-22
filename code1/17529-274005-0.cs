    using System;
    using System.Reflection;
        
    
    class Program
    {
        static void Main(string[] args)
        {
            MagicAttributeSearcher(typeof(Sedan));
            MagicAttributeSearcher(typeof(Vehicle));
        }
        
        static void MagicAttributeSearcher(Type type)
        {
            PropertyInfo prop = type.GetProperty("TurningRadius");
            var attr = Attribute.GetCustomAttribute(prop, typeof(MyAttribute), false);
            Console.WriteLine("{0}: {1}", type, attr);
        }
    }
