        static void Main(string[] args)
        {
            foreach (var prop in typeof(Sub).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
            {
                foreach (var attrib in prop.GetCustomAttributes(typeof(DescriptionAttribute), false))
                {
                    Console.WriteLine(prop.Name);
                }
            }
            Console.ReadKey(true);
        }
    
    public class Base
    {
        [Description]
        public int IntProp { get; set; }
    }
    public class Sub : Base
    {
        [Description]
        public string StringProp { get; set; }
    }
