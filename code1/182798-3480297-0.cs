    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace SBTest
    {
        class Program
        {
            private const int ITERATIONS = 1000000;
    
            private static void Main(string[] args)
            {
                Test1();
                Test2();
                Test3();
            }
    
            private static void Test1()
            {
                var sw = Stopwatch.StartNew();
                var sb = new StringBuilder();
    
                for (var i = 0; i < ITERATIONS; i++)
                {
                    sb.Append("TEST" + i.ToString("00000"),
                              "TEST" + (i + 1).ToString("00000"),
                              "TEST" + (i + 2).ToString("00000"));
                }
    
                sw.Stop();
                Console.WriteLine("Testing Append() extension method...");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Test 1 iterations: {0:n0}", ITERATIONS);
                Console.WriteLine("Test 1 milliseconds: {0:n0}", sw.ElapsedMilliseconds);
                Console.WriteLine("Test 1 output length: {0:n0}", sb.Length);
                Console.WriteLine("");
            }
    
            private static void Test2()
            {
                var sw = Stopwatch.StartNew();
                var sb = new StringBuilder();
    
                for (var i = 0; i < ITERATIONS; i++)
                {
                    sb.Append("TEST" + i.ToString("00000"));
                    sb.Append("TEST" + (i+1).ToString("00000"));
                    sb.Append("TEST" + (i+2).ToString("00000"));
                }
                sw.Stop();    
                Console.WriteLine("Testing multiple calls to Append() built-in method...");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Test 2 iterations: {0:n0}", ITERATIONS);
                Console.WriteLine("Test 2 milliseconds: {0:n0}", sw.ElapsedMilliseconds);
                Console.WriteLine("Test 2 output length: {0:n0}", sb.Length);
                Console.WriteLine("");
            }
    
            private static void Test3()
            {
                var sw = Stopwatch.StartNew();
                var sb = new StringBuilder();
    
                for (var i = 0; i < ITERATIONS; i++)
                {
                    sb.AppendFormat("{0}{1}{2}",
                        "TEST" + i.ToString("00000"),
                        "TEST" + (i + 1).ToString("00000"),
                        "TEST" + (i + 2).ToString("00000"));
                }
    
                sw.Stop();
                Console.WriteLine("Testing AppendFormat() built-in method...");
                Console.WriteLine("--------------------------------------------");            
                Console.WriteLine("Test 3 iterations: {0:n0}", ITERATIONS);
                Console.WriteLine("Test 3 milliseconds: {0:n0}", sw.ElapsedMilliseconds);
                Console.WriteLine("Test 3 output length: {0:n0}", sb.Length);
                Console.WriteLine("");
            }
        }
    
        public static class SBExtentions
        {
            public static void Append(this StringBuilder sb, params string[] args)
            {
                foreach (var arg in args)
                    sb.Append(arg);
            }
        }
    }
