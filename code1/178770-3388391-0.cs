    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication19
    {
        class Program
        {
            static void Main(string[] args)
            {
                TimeSpan throwAwayString = StringTest(100);
                TimeSpan throwAwayChar = CharTest(100);
                TimeSpan realStringTime = StringTest(10000000);
                TimeSpan realCharTime = CharTest(10000000);
                Console.WriteLine("string time: {0}", realStringTime);
                Console.WriteLine("char time: {0}", realCharTime);
                Console.ReadLine();
            }
    
            private static TimeSpan StringTest(int attemptCount)
            {
                Stopwatch sw = new Stopwatch();
                string concatResult = string.Empty;
                sw.Start();
                for (int counter = 0; counter < attemptCount; counter++)
                    concatResult = counter.ToString() + ".";
                sw.Stop();
                return sw.Elapsed;
            }
    
            private static TimeSpan CharTest(int attemptCount)
            {
                Stopwatch sw = new Stopwatch();
                string concatResult = string.Empty;
                sw.Start();
                for (int counter = 0; counter < attemptCount; counter++)
                    concatResult = counter.ToString() + '.';
                sw.Stop();
                return sw.Elapsed;
            }
        }
    }
