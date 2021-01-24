    using System;
    using System.Diagnostics;
    
    public static class Module1
    {
        public static void Main()
        {
            System.Collections.Concurrent.ConcurrentBag<int> bag = new System.Collections.Concurrent.ConcurrentBag<int>();
    		// Test Bag Parallel
            Stopwatch t = Stopwatch.StartNew();
            System.Threading.Tasks.Parallel.For(0, 500000, index =>
            {
                bag.Add(index);
            });
            t.Stop();
            Console.WriteLine("Parallel Bag test completed in " + t.ElapsedTicks.ToString());
    		// Test Bag Incremental
            bag = new System.Collections.Concurrent.ConcurrentBag<int>();
            t = Stopwatch.StartNew();
            for (int index = 0; index <= 500000; index += 1)
            {
                bag.Add(index);
            }
            t.Stop();
            Console.WriteLine("Incremental Bag test completed in " + t.ElapsedTicks.ToString());
            bag = null;
    		// Test List Incremental
            t = Stopwatch.StartNew();
            System.Collections.Generic.List<int> lst = new System.Collections.Generic.List<int>();
            t = Stopwatch.StartNew();
            for (int index = 0; index <= 500000; index += 1)
            {
                lst.Add(index);
            }
            t.Stop();
            Console.WriteLine("Incremental list test completed in " + t.ElapsedTicks.ToString());
        }
    }
