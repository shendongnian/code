    using System;
    using System.Collections;
    
    static class Program
    {
        public static Type GetDeclaredType<T>(T obj)
        {
            return typeof(T);
        }
    
        static void Main(string[] args)
        {
            ICollection iCollection = new List<string>();
            IEnumerable iEnumerable = new List<string>();
    
            Type[] types = new Type[]{
                    GetDeclaredType(iCollection),
                    GetDeclaredType(iEnumerable)
            };
    
            foreach (Type t in types)
                Console.WriteLine(t.Name);
        }
    }
