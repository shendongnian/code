    using System;
    using System.Collections.Generic;
    
    static class Program
    {
        public static Type GetDeclaredType<T>(T obj)
        {
            return typeof(T);
        }
    
        // Demonstrate how GetDeclaredType works
        static void Main(string[] args)
        {
            IList<string> iList = new List<string>();
            List<string> list = null;
            Console.WriteLine(GetDeclaredType(iList).Name);
            Console.WriteLine(GetDeclaredType(list).Name);
        }
    }
