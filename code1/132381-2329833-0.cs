    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
                object[] os = t.GetType().GetProperty("Title").GetCustomAttributes(typeof(DatabaseFieldAttribute), true);
    
                if (os != null && os.Length >= 1)
                    Console.WriteLine((os[0] as DatabaseFieldAttribute).Name);
            }
    
    
        }
    
        public class Test
        {
            [DatabaseField("titlezzz")]
            public string Title { get; set; }
        }
    
        public class DatabaseFieldAttribute : Attribute
        {
            private readonly string _name;
    
            public string Name { get { return _name; } }
    
            public DatabaseFieldAttribute(string name)
            {
                _name = name;
            }
        }
    
    }
