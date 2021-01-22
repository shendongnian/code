    using System;
    using System.Reflection;
    
    public abstract class Base<T>
    {
    }
    
    public class Concrete : Base<string>
    {
    }
    
    class Test
    {
        static void Main()
        {
            Type type = typeof(Concrete);
            Type baseType = type.BaseType;
            Type typeOfT = baseType.GetGenericArguments()[0]; // Only one arg
            Console.WriteLine(typeOfT.Name); // Prints String
        }
    }
