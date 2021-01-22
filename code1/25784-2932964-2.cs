    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    
    namespace RangeTests
    {
      class TestRange
      {
        public static void Main(string[] args)
        {
          for(int l = 1; l <= 2; ++l)
          {
            const int N = 900000000;
            System.GC.Collect(2);
            // for loop
            {
                Stopwatch sw = Stopwatch.StartNew();
    
                long accumulator = 0;
                for (int i = 1; i <= N; ++i)
                {
                    accumulator += i;
                }
    
                sw.Stop();
    
                Console.WriteLine("time = {0}; result = {1}", sw.ElapsedMilliseconds, accumulator);
            }
            System.GC.Collect(2);
    
            //Enumerable.Range
            {
                Stopwatch sw = Stopwatch.StartNew();
    
                var ret = Enumerable.Range(1, N).Aggregate(0, (long accumulator,int n) => accumulator + n);
    
                sw.Stop();
                Console.WriteLine("time = {0}; result = {1}", sw.ElapsedMilliseconds, ret);
            }
            System.GC.Collect(2);
    
            //self-made IEnumerable<int>
            {
                Stopwatch sw = Stopwatch.StartNew();
    
                var ret = GetIntRange(1, N).Aggregate(0, (long accumulator,int n) => accumulator + n);
    
                sw.Stop();
                Console.WriteLine("time = {0}; result = {1}", sw.ElapsedMilliseconds, ret);
            }
            System.GC.Collect(2);
    
            //self-made adjusted IEnumerable<int>
            {
                Stopwatch sw = Stopwatch.StartNew();
    
                var ret = GetRange(1, N).Aggregate(0, (long accumulator,int n) => accumulator + n);
    
                sw.Stop();
                Console.WriteLine("time = {0}; result = {1}", sw.ElapsedMilliseconds, ret);
            }
            System.GC.Collect(2);
            Console.WriteLine();
        } }
    
        private static IEnumerable<int> GetIntRange(int start, int count)
        {
            int end = start + count;
    
            for (int i = start; i < end; ++i)
            {
                yield return i;
            }
        }
    
        private static IEnumerable<int> GetRange(int start, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                yield return start + i;
            }
        }
    } }
