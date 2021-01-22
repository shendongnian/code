    using System;
    using System.Reflection;
    
    public static class ObjectExtensions
    {
        public static string TryToString(this object x)
        {
            // Just guessing...
            return x == null ? "" : x.ToString();
        }
    }
    
    class Test
    {
        static void Main()
        {
            var method = typeof(ObjectExtensions).GetMethod
                ("TryToString", BindingFlags.Public | BindingFlags.Static);
            // Prints System.String TryToString(System.Object)
            Console.WriteLine(method);
        }
    }
