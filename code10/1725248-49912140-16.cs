    using System;
    using System.Threading;
    
    namespace Question_Answer_Console_App
    {
        class Program
        {
            private const int SleepTimeMS = 10000;
            static void Main(string[] args)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback((state) =>
                {
                    while (true)
                    {
                        Thread.Sleep(SleepTimeMS);
                        AddNumbers(2, 2);
                        Console.WriteLine("The current time now is :{0}", DateTime.Now.ToString());
                    }
                }));
    
                Console.Read();
            }
    
            private static void AddNumbers(int x, int y)
            {
                var sum = x + y;
                Console.WriteLine(sum);
            }
        }
    }
