    using System;
    using System.Diagnostics;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {
            // Make sure everything's JITted
            Time(Sequential, 1);
            Time(Parallel, 1);
            // Now run the real tests
            Time(Sequential, 1000000000);
            Time(Parallel, 100000000);
        }
        
        static void Time(Func<int, int> action, int count)
        {
            GC.Collect();
            Stopwatch sw = Stopwatch.StartNew();
            int check = action(count);
            if (count != check)
            {
                Console.WriteLine("Check for {0} failed!", action.Method.Name);
            }
            sw.Stop();
            Console.WriteLine("Time for {0} with count={1}: {2}ms",
                              action.Method.Name, count,
                              (long) sw.ElapsedMilliseconds);
        }
        
        static int Sequential(int count)
        {
            var strList = Enumerable.Repeat(1, count);
            return strList.Sum();
        }
    
        static int Parallel(int count)
        {
            var strList = Enumerable.Repeat(1, count);
            return strList.AsParallel().Sum();
        }
    }
