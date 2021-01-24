    namespace CompileTimeIntegerTest
    {
        public class Program
        {
            const int a = unchecked((int)0xC0000000);
    
            public static void Main(string[] args)
            {
                Console.WriteLine("{0:X}", a);
            }
        }
    }
