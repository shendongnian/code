     public class TestClass
        {
            [ConditionalAttribute("DEBUG")]
            public static void Test()
            {
                Console.WriteLine("Blierpie");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Starting test");
                TestClass.Test();
                Console.WriteLine("Finished test");
                Console.ReadKey();
            }
        }
