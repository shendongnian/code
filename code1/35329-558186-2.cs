    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Pair<T, U>
        {
            public T Item1 { get; private set; }
            public U Item2 { get; private set; }
            public Pair(T item1, U item2)
            {
                this.Item1 = item1;
                this.Item2 = item2;
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Pair<int, double>[] nums = new Pair<int, double>[1000];
                Random r = new Random();
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = new Pair<int, double>(i, r.NextDouble());
                }
    
                Array.Sort<Pair<int, double>>(nums, (x, y) => x.Item2.CompareTo(y.Item2));
    
                foreach (var item in nums)
                {
                    Console.Write("{0} ", item.Item1);
                }
    
                Console.ReadKey(true);
            }
        }
    }
