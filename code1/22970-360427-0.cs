    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                System.Reflection.PropertyInfo[] tmp2
                     = typeof(TestClass).GetProperties();
                System.Reflection.PropertyInfo test
                     = typeof(TestClass).GetProperty("TestProp", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
    
                Console.WriteLine(test.Name);
            }
        }
    
        public class TestClass
        {
            public Int32 TestProp
            {
                get
                {
                    return 0;
                }
                set
                {
                }
            }
        }
    }
