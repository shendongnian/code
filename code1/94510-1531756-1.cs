    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    class Test
    {
        static List<int> ints = Enumerable.Range(0, 10000000).ToList();
        
        static void Main(string[] args)
        {
            Benchmark("All", i => i >= 0); // Match all
            Benchmark("Half", i => i % 2 == 0); // Match half
            Benchmark("None", i => i < 0); // Match none
        }
        
        static void Benchmark(string name, Predicate<int> predicate)
        {
            // We could just use new Func<int, bool>(predicate) but that
            // would create one delegate wrapping another.
            Func<int, bool> func = (Func<int, bool>) 
                Delegate.CreateDelegate(typeof(Func<int, bool>), predicate.Target,
                                        predicate.Method);
            Benchmark("FindAll: " + name, () => ints.FindAll(predicate));
            Benchmark("Where: " + name, () => ints.Where(func).Count());
        }
        
        static void Benchmark(string name, Action action)
        {
            GC.Collect();
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 50; i++)
            {
                action();
            }
            sw.Stop();
            Console.WriteLine("{0}: {1}", name, sw.ElapsedMilliseconds);
        }
    }
