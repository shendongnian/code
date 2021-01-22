    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test();
    
                Console.WriteLine(t.FieldName("Title").FieldName<DatabaseFieldAttribute>());
                Console.WriteLine(t.FieldName("Title").FieldIsPrimaryKey<DatabaseFieldAttribute>());
            }
    
    
        }
    
        public class Test
        {
            [DatabaseField("titlezzz", true)]
            public string Title
            {
                get;
                set;
            }
        }
    
    
        public class BaseDatabaseFieldAttribute : Attribute
        {
            private readonly string _name;
    
            public string Name { get { return _name; } }
    
            public BaseDatabaseFieldAttribute(string name)
            {
                _name = name;
            }
        }
        public class DatabaseFieldAttribute : BaseDatabaseFieldAttribute
        {
            private readonly bool _isPrimaryKey;
    
            public bool IsPrimaryKey { get { return _isPrimaryKey; } }
    
            public DatabaseFieldAttribute(string name, bool isPrimaryKey): base(name)
            {
                _isPrimaryKey = isPrimaryKey;
            }
        }
    
        public static class Helper
        {
    
            public static PropertyInfo FieldName(this object obj, string propertyName)
            {
                return obj.GetType().GetProperty(propertyName);
            }
    
            public static string FieldName<T>(this PropertyInfo property) where T: BaseDatabaseFieldAttribute
            {
                object[] os = property.GetCustomAttributes(typeof(T), false);
                
                if (os != null && os.Length >= 1)
                    return (os[0] as T).Name;
                else
                    return "N/A";
            }
    
            public static bool? FieldIsPrimaryKey<T>(this PropertyInfo property) where T : DatabaseFieldAttribute
            {
                object[] os = property.GetCustomAttributes(typeof(T), false);
    
                if (os != null && os.Length >= 1)
                    return (os[0] as T).IsPrimaryKey;
                else
                    return null;
            }
        }
    
    
    }
