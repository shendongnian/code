    using System;
    using System.Threading;
    namespace Question_Answer_Console_App
    {
        class Program
        {
            private const int SleepTimeMS = 10000;
            static void Main(string[] args)
            {
                while (true)
                {
                    Thread.Sleep(SleepTimeMS);
                    AddNumbers(2, 2);
                    Console.WriteLine("The current time now is :{0}", DateTime.Now.ToString());
                }
            }
    
            private static void AddNumbers(int x, int y)
            {
                var sum = x + y;
                Console.WriteLine(sum);
            }
        }
    }
