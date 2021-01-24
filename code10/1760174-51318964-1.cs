    public class Tester
    {
        public string SuperProperty { get; set; }
    }
    
    public class Test : Tester
    {
        public string SubProperty { get; set; }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var props = typeof(Test).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
            
            foreach (PropertyInfo p in props)
                Console.WriteLine(p.Name); // print only SubProperty
        }
    }
