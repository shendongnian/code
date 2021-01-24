    using System;
    
    namespace test
    {
        class Program
        {
            public string test;
    
            public static void Main(string[] args)
            {
                var program = new Program()
                program.test = "hi!!";
                Console.WriteLine(program.test);
                Main2(program);
                Console.ReadKey(true);
            }
    
            public static void Main2(program){
                Console.WriteLine(program.test);
                Console.ReadKey(true);
            }
        }
    }
