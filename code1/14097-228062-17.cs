    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            delegate string StringDelegate(string s);
    
            static void Benchmark(string description, StringDelegate d, int times, string text)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int j = 0; j < times; j++)
                {
                    d(text);
                }
                sw.Stop();
                Console.WriteLine("{0} Milliseconds {1} : called {2} times.", sw.ElapsedMilliseconds, description, times);
            }
    
            public static string ReverseSB(string text)
            {
                StringBuilder builder = new StringBuilder(text.Length);
                for (int i = text.Length - 1; i >= 0; i--)
                {
                    builder.Append(text[i]);
                }
                return builder.ToString();
            }
    
            public static string ReverseArray(string text)
            {
                char[] array = text.ToCharArray();
                Array.Reverse(array);
                return (new string(array));
            }
    
            static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 10000; i++)
                {
                    sb.Append("aB");
                }
                string longString = sb.ToString();
                string shortString = "Hello";
    
                Benchmark("Long String String Builder", ReverseSB, 10000, longString);
                Benchmark("Long String Array.Reverse", ReverseArray, 10000, longString);
                Benchmark("Short String String Builder", ReverseSB, 100000, shortString);
                Benchmark("Short String Array.Reverse", ReverseArray, 100000, shortString);
    
                Console.Read();
            }
        }
    }
