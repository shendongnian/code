    using System;
    using System.Diagnostics;
    
    public class ContainsStartsWith
    {
        public static void Main()
        {
            string str = "Hello there";
            
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < 10000000; i++)
            {
                str.Contains("H");
            }
            s.Stop();
            Console.WriteLine("{0}ms using Contains", s.Elapsed.TotalMilliseconds);
    
            s.Reset();
            s.Start();
            for (int i = 0; i < 10000000; i++)
            {
                str.StartsWith("H");
            }
            s.Stop();
            Console.WriteLine("{0}ms using StartsWith", s.Elapsed.TotalMilliseconds);
    
        }
    }
