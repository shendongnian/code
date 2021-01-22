    using System;
    using System.Diagnostics;
    
    class Program
    {
        public static void Main()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
    
                // some other code
    
            stopWatch.Stop();
    
            // this not correct to get full timer resolution
            Console.WriteLine("{0} ms", stopWatch.ElapsedMilliseconds);
    
            // Correct way to get accurate high precision timing
            Console.WriteLine("{0} ms", stopWatch.Elapsed.TotalMilliseconds);
        }
    }
