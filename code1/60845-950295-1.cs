    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    
    namespace stringtestloop
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch w = new Stopwatch();
                int itterations = 1024 * 1024 * 512;
                
                w.Start();
                string var1 = string.Empty;
                for (var i = 0; i < itterations; i++)
                {
                    var1 = "some string";
                }
                w.Stop();
    
                Console.WriteLine("outside: {0} ms", w.ElapsedMilliseconds);
    
                w.Reset();
    
                w.Start();
                for (var i = 0; i < itterations; i++)
                {
                    string var2 = "some string";
                }
                w.Stop();
    
                Console.WriteLine("inside: {0} ms", w.ElapsedMilliseconds);
                Console.ReadKey();
            }
        }
    }
