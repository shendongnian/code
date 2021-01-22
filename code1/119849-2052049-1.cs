    public class SkipPropertyAttribute : Attribute
    {
    }
    
    public static class TypeExtensions
    {
        public static PropertyInfo[] GetFilteredProperties(this Type type)
        {
            return type.GetProperties().Where(pi => pi.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0).ToArray();
        }		
    }
    
    public class Test
    {
        public string One { get; set; }
    
        [SkipProperty]
        public string Two { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var t = new Test();
            Type ty = t.GetType();
    
            PropertyInfo[] pinfo = ty.GetFilteredProperties();
            foreach (PropertyInfo p in pinfo)
            {
                Console.WriteLine(p.Name);
            }
    
            Console.ReadKey();
        }
    }
