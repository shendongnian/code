    using System;
    using System.Diagnostics;
    namespace CompareTest
    {
        static class Program
        {
            static void Main(string[] args)
            {
                int iterations = 10000000;
                int a = 5;
                string b = "5";
                Stopwatch toStringStopwatch = new Stopwatch();
                toStringStopwatch.Start();
                for (int i = 0; i < iterations; i++) {
                    bool dummyState = a.ToString() == b;
                }
                toStringStopwatch.Stop();
                Stopwatch parseStopwatch = new Stopwatch();
                parseStopwatch.Start();
                for (int i = 0; i < iterations; i++) {
                    bool dummyState = a == int.Parse(b);
                }
                parseStopwatch.Stop();
                Console.WriteLine("ToString(): {0}", toStringStopwatch.Elapsed);
                Console.WriteLine("Parse(): {0}", parseStopwatch.Elapsed);
                Console.ReadLine();
            }
        }
    }
