    using System;
    using System.Diagnostics;
    using System.Linq;
    
    public class Test
    {
        const int Iterations = 1000000000;
        static void Main()
        {
            // Make sure everything's JITted
            Time(Sequential, 1);
            Time(Parallel, 1);
            Time(Parallel2, 1);
            // Now run the real tests
            Time(Sequential, Iterations);
            Time(Parallel,   Iterations);
            Time(Parallel2,  Iteration);
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
        static int Parallel2(int count)
        {
            var strList = ParallelEnumerable.Repeat(1, count);
            return strList.Sum();
        }
    }
