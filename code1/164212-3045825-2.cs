    using System;
    using System.Collections.Generic;
    using System.Linq;
    using LVK.DataStructures.Collections;
    
    namespace SO3045604
    {
        class LowestComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                return x.Item1.CompareTo(y.Item1);
            }
        }
    
        class HighestComparer : IComparer<Tuple<int, int>>
        {
            public int Compare(Tuple<int, int> x, Tuple<int, int> y)
            {
                return -x.Item1.CompareTo(y.Item1);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                int[] values = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    
                var valuesWithPositions = values
                    .Select((value, index) => Tuple.Create(value, index));
    
                var loHeap = new Heap<Tuple<int, int>>(
                    new LowestComparer(),
                    valuesWithPositions);
                var hiHeap = new Heap<Tuple<int, int>>(
                    new HighestComparer(),
                    valuesWithPositions);
    
                int sum = values.Aggregate((a, b) => a + b);
    
                while (sum < 75)
                {
                    var lowest = loHeap[0];
                    values[lowest.Item2]++;
                    loHeap.ReplaceAt(0, 
                        Tuple.Create(lowest.Item1 + 1, lowest.Item2));
                    sum++;
                }
                while (sum > 55)
                {
                    var highest = hiHeap[0];
                    values[highest.Item2]--;
                    hiHeap.ReplaceAt(0,
                        Tuple.Create(highest.Item1 - 1, highest.Item2));
                    sum--;
                }
                // at this point, the sum of the values in the array is now 55
                // and the items have been modified as per your algorithm
            }
        }
    }
