    using System;
    static class Program
    {
        public static Type GetDeclaredType<T>(this T obj)
        {
            return typeof(T);
        }
    
        // Demonstrate how GetDeclaredType works
        static void Main(string[] args)
        {
            ICollection iCollection = new List<string>();
            IEnumerable iEnumerable = new List<string>();
            IList<string> iList = new List<string>();
            List<string> list = null;
    
            Type[] types = new Type[]{
                iCollection.GetDeclaredType(),
                iEnumerable.GetDeclaredType(),
                iList.GetDeclaredType(),
                list.GetDeclaredType()
            };
    
            foreach (Type t in types)
                Console.WriteLine(t.Name);
        }
    }
