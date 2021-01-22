    using System;
    
    namespace ConsoleApplication20
    {
        public class Test
        {
            public int Value;
    
            ~Test()
            {
                Console.Out.WriteLine("Test collected");
            }
    
            public void Execute()
            {
                Console.Out.WriteLine("The value of Value: " + Value);
    
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
    
                Console.Out.WriteLine("Leaving Test.Execute");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Test t = new Test { Value = 15 };
                t.Execute();
            }
        }
    }
