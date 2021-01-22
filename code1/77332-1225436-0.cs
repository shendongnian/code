    using System;
    using System.Linq;
    using System.Threading;
    
    namespace GeneralTestApplication
    {
        class Program
        {
            private static void Main()
            {
                Console.WriteLine("Enter the number of threads to start.");
    
                while (!Int32.TryParse(Console.ReadLine(), out Program.numberThreads)) { }
    
                Program.counters = new Int64[Program.numberThreads];
    
                for (Int32 threadNumber = 0; threadNumber < Program.numberThreads; threadNumber++)
                {
                    new Thread(Program.ThreadMethod).Start(threadNumber);
                }
    
                Console.WriteLine("Press enter to start {0} threads.", Program.numberThreads);
                Console.ReadLine();
    
                Program.manualResetEvent.Set();
    
                Console.WriteLine("Press enter to stop all threads.");
                Console.ReadLine();
    
                Program.stop = true;
    
                Console.WriteLine("At least {0} threads ran.", Program.counters.Count(c => c > 0));
    
                Console.ReadLine();
            }
    
            private static Int32 numberThreads = 0;
            private static Int64[] counters = null;
            private static readonly ManualResetEvent manualResetEvent = new ManualResetEvent(false);
            private static volatile Boolean stop = false;
    
            public static void ThreadMethod(Object argument)
            {
                Int32 threadNumber = (Int32)argument;
    
                Program.manualResetEvent.WaitOne();
    
                while (!Program.stop)
                {
                    Program.counters[threadNumber]++;
    
                    // Uncomment to simulate heavy work.
                    Thread.Sleep(10);
                }
            }
        }
    }
