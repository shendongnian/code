    using System;
    using System.Reflection;
    
    public class Foo
    {
        public static Foo operator +(Foo x, Foo y)
        {
            return new Foo();
        }
        
        public static implicit operator string(Foo x)
        {
            return "";
        }
    }
    
    public class Example 
    {
        
        public static void Main()
        {
            foreach (MethodInfo method in typeof(Foo).GetMethods())
            {
                if (method.IsSpecialName)
                {
                    Console.WriteLine(method.Name);
                }
            }
        }
    }
