    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                string abc = "HELLO";
                Console.WriteLine("My result: {0}", ClassB(abc));
                Console.Read();
            }
    
            public static string ClassB(string abc)
            {
                return abc;
            }
        }
    }
