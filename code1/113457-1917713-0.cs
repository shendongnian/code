    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    namespace ToStringTest
    {
        class Program
        {
            const int
                iterationCount = 1000000;
            static TimeSpan Test1()
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                string str = "12345";
                int j = 12345;
                for (int i = 0; i < iterationCount; i++)
                {
                    if (str == i.ToString())
                    {
                        //do my logic
                    }
                }
                watch.Stop();
                return watch.Elapsed;
            }
            static TimeSpan Test2()
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                string str = "12345";
                int j = 12345;
                for (int i = 0; i < iterationCount; i++)
                {
                    if (Convert.ToInt32(i) == j)
                    {
                        //do my logic
                    }
                }
                watch.Stop();
                return watch.Elapsed;
            }
            static void Main(string[] args)
            {
                Console.WriteLine("ToString = " + Test1().TotalMilliseconds);
                Console.WriteLine("Convert = " + Test2().TotalMilliseconds);
            }
        }
    }
