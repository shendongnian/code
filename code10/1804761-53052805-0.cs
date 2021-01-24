       class Program
        {
            static void Main(string[] args)
            {
                ReflectOverProperties<TestClass, TestClass2>(new TestClass(), new TestClass2());
                Console.ReadLine();
            }
    
            public static void ReflectOverProperties<T, Z>(T x, Z y)
            {
                var properties = typeof(T).GetProperties();
                foreach (var item in properties)
                {
                    CompareProperty(x, y, item.Name);
    
                }
            }
    
            private static void CompareProperty<T, Z>(T x, Z y, string itemName)
            {
                dynamic originalValue = GetPropValue(x, itemName);
                dynamic newValue = GetPropValue(y, itemName);
                PropertyCompare(itemName, originalValue, newValue);
    
            }
    
            private static void PropertyCompare(string itemName, dynamic originalValue, dynamic newValue)
            {
                if (originalValue != newValue)
                {
                 Console.Write($"Property {itemName} does not match");
                }
            }
    
        
    
            public static object GetPropValue(object src, string propName)
            {
                return src.GetType().GetProperty(propName).GetValue(src, null);
            }
        }
    
        public class TestClass
        {
            public TestClass()
            {
                Test1 = false;
                Test2 = false;
                Test3 = false;
            }
            public bool Test1 { get; set; }
            public bool Test2 { get; set; }
            public bool Test3 { get; set; }
        }
        public class TestClass2
        {
            public TestClass2()
            {
                Test1 = false;
                Test2 = false;
                Test3 = true;
            }
            public bool Test1 { get; set; }
            public bool Test2 { get; set; }
            public bool Test3 { get; set; }
        }
