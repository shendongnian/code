    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] a)
            {
                Random random = new Random();
                List<int> list1 = new List<int>(); //source list
                List<int> list2 = new List<int>();
                list2 = random.SequenceWhile((i) =>
                     {
                         if (list2.Contains(i))
                         {
                             return false;
                         }
                         list2.Add(i);
                         return true;
                     },
                     () => list2.Count == list1.Count,
                     list1.Count).ToList();
    
            }
        }
        public static class RandomExtensions
        {
            public static IEnumerable<int> SequenceWhile(
                this Random random, 
                Func<int, bool> shouldSkip, 
                Func<bool> continuationCondition,
                int maxValue)
            {
                int current = random.Next(maxValue);
                while (continuationCondition())
                {
                    if (!shouldSkip(current))
                    {
                        yield return current;
                    }
                    current = random.Next(maxValue);
                }
            }
        }
    }
