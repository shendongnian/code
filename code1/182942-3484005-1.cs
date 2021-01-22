    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    
    class Program
    {
        static void Main()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
    
            // Declaration.txt is a copy of the Declaration of Independence
            // which can be found here: http://en.wikisource.org/wiki/United_States_Declaration_of_Independence
            string declaration = File.ReadAllText("Declaration.txt");
            string[] items = declaration.ToLower().Split(new char[] { ',', '.', ':', ';', '-', '\r', '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    
            Console.WriteLine("Total words: {0}", items.Length);
            // pre-execute outside timing loop
            LinqMethodToArray(items);
            LinqMethod(items);
            HashMethod(items);
    
            int iterations = 1000;
            long min1 = long.MaxValue, max1 = long.MinValue, sum1 = 0;
            long min2 = long.MaxValue, max2 = long.MinValue, sum2 = 0;
            long min3 = long.MaxValue, max3 = long.MinValue, sum3 = 0;
    
            Stopwatch sw = new Stopwatch();
    
            for (int n = 0; n < iterations; n++)
            {
                sw.Reset();
                sw.Start();
                LinqMethodToArray(items);
                sw.Stop();
                sum1 += sw.ElapsedTicks;
                if (sw.ElapsedTicks < min1)
                    min1 = sw.ElapsedTicks;
                if (sw.ElapsedTicks > max1)
                    max1 = sw.ElapsedTicks;
    
                sw.Reset();
                sw.Start();
                LinqMethod(items);
                sw.Stop();
                sum2 += sw.ElapsedTicks;
                if (sw.ElapsedTicks < min2)
                    min2 = sw.ElapsedTicks;
                if (sw.ElapsedTicks > max2)
                    max2 = sw.ElapsedTicks;
    
                sw.Reset();
                sw.Start();
                HashMethod(items);
                sw.Stop();
                sum3 += sw.ElapsedTicks;
                if (sw.ElapsedTicks < min3)
                    min3 = sw.ElapsedTicks;
                if (sw.ElapsedTicks > max3)
                    max3 = sw.ElapsedTicks;
            }
    
            Console.WriteLine("{0,-10} {1,-10} {2,-10} Method", "Min", "Max", "Mean");
            Console.WriteLine("{0,-10} {1,-10} {2,-10} LinkMethodToArray", min1, max1, (double)sum1 / iterations);
            Console.WriteLine("{0,-10} {1,-10} {2,-10} LinkMethod", min2, max2, (double)sum2 / iterations);
            Console.WriteLine("{0,-10} {1,-10} {2,-10} HashMethod", min3, max3, (double)sum3 / iterations);
        }
    
        static void LinqMethodToArray(string[] items)
        {
            var ranking = (from item in items
                           group item by item into r
                           orderby r.Count() descending
                           select new { Name = r.Key, Rank = r.Count() }).ToArray();
            for (int n = 0; n < ranking.Length; n++)
            {
                var item = ranking[n];
                DoSomethingWithItem(item);
            }
        }
    
        static void LinqMethod(string[] items)
        {
            var ranking = (from item in items
                           group item by item into r
                           orderby r.Count() descending
                           select new { Name = r.Key, Rank = r.Count() });
            foreach (var item in ranking)
                DoSomethingWithItem(item);
        }
    
        static void HashMethod(string[] items)
        {
            var ranking = new Dictionary<string, int>();
            foreach (string item in items)
            {
                if (!ranking.ContainsKey(item))
                    ranking[item] = 1;
                else
                    ranking[item]++;
            }
            foreach (KeyValuePair<string, int> pair in ranking)
                DoSomethingWithItem(pair);
    
        }
    
        static volatile object hold;
        static void DoSomethingWithItem(object item)
        {
            // This method exists solely to prevent the compiler from
            // optimizing use of the item away so that this program
            // can be executed in Release build, outside the debugger.
            hold = item;
        }
    }
