    using System.Reflection;
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                PropertyInfo[] tmp2 = typeof(TestClass).GetProperties();
                PropertyInfo test = typeof(TestClass).GetProperty(
                    "TestProp",
                    BindingFlags.Instance | BindingFlags.Public |
                        BindingFlags.NonPublic);
    
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
