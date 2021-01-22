    using System;
    using System.Reflection;
    
    public class MyAttribute : Attribute
    {
        public MyAttribute(int x) {}
    }
    
    public class Sedan : Car
    {
        // ...
    }
    
    public class Car : Vehicle
    {
        public override int TurningRadius { get; set; }
    }
    
    public abstract class Vehicle
    {
        [MyAttribute(1)]
        public virtual int TurningRadius { get; set; }
    }
    
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
