    using System;
    using System.Diagnostics;
    
    namespace TestDriver
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Start the stopwatch
                if (Stopwatch.IsHighResolution)
                { Console.WriteLine("Using high resolution timer"); }
                else
                { Console.WriteLine("High resolution timer unavailable"); }
                // Test Math.Min for 10000 iterations
                Stopwatch sw = Stopwatch.StartNew();
                for (int ndx = 0; ndx < 10000; ndx++)
                {
                    int result = Math.Min(ndx, 5000);
                }
                Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString("0.0000"));
                // Test trinary operator for 10000 iterations
                sw = Stopwatch.StartNew();
                for (int ndx = 0; ndx < 10000; ndx++)
                {
                    int result = (ndx < 5000) ? ndx : 5000;
                }
                Console.WriteLine(sw.Elapsed.TotalMilliseconds.ToString("0.0000"));
                Console.ReadKey();
            }
        }
    }
