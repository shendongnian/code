     class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
                object[] os = t.GetType().GetProperty("Title").GetCustomAttributes(typeof(DatabaseFieldAttribute), true);
    
                //if (os != null && os.Length >= 1)
                //    Console.WriteLine((os[0] as DatabaseFieldAttribute).Name);
    
                
    
                Console.WriteLine(t.GetTitle());
            }
    
    
        }
    
        public class Test
        {
            [DatabaseField("titlezzz")]
            public string Title 
            {
                get
                {
                    return "";
                }
                set
                {
    
                }
            }
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
    
        public static class Helper
        {
            public static string GetTitle(this Test test)
            {
                object[] os = test.GetType().GetProperty("Title").GetCustomAttributes(typeof(DatabaseFieldAttribute), true);
    
                if (os != null && os.Length >= 1)
                    return (os[0] as DatabaseFieldAttribute).Name;
                else
                    return "N/A";
            }
        }
