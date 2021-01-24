    using System;
    
    namespace test
    {
        class Program
        {
            public static string test;
    
            public static void Main(string[] args)
            {
                test = "hi!!";
                Console.WriteLine(test);
                Main2();
                Console.ReadKey(true);
            }
    
            public static void Main2(){
                Console.WriteLine(test);
                Console.ReadKey(true);
            }
        }
    }
