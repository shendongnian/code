    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<int> ints = 
                    new List<int> { 1,2,3,4,5,6,7,8,9,10};
    
                Console.WriteLine("Iterating over Odd numbers only.");
                foreach (int i in ints.Odd())
                {
                    Console.WriteLine(i);
                }
    
                Console.WriteLine("Iterating over Even numbers only.");
                foreach (int i in ints.Even())
                {
                    Console.WriteLine(i);
                }
    
                Console.WriteLine("Iterating over the list in reversed order.");
                foreach (int i in ints.Reversed())
                {
                    Console.WriteLine(i);
                }
    
                Console.WriteLine("Iterating over the list in random order.");
                foreach (int i in ints.Random())
                {
                    Console.WriteLine(i);
                }
    
                Console.ReadLine();
            }
        }
    
        public static class ListExtensions
        {
            /// <summary>
            /// Iterates over the list only returns even numbers
            /// </summary>
            /// <param name="list"></param>
            public static IEnumerable<int> Even(this List<int> list)
            {
                foreach (var i in list)
                {
                    if (i % 2 == 0)
                     {
                        yield return i;
                    }
               }
            }
    
            /// <summary>
            /// Iterates over the list only returns odd numbers
            /// </summary>
            public static IEnumerable<int> Odd(this List<int> list)
            {
                foreach (var i in list)
                {
                    if (i % 2 != 0)
                    {
                        yield return i;
                    }
                }
            }
    
            /// <summary>
            /// Iterates over the list in reversed order
            /// </summary>
            public static IEnumerable<int> Reversed(this List<int> list)
            {
                for (int i = list.Count; i >= 0; i--)
                {
                    yield return i;
                }
            }
    
            /// <summary>
            /// Iterates over the list in reversed order
            /// </summary>
            public static IEnumerable<int> Random(this List<int> list)
            {
                // Initialize a random number generator with a seed.
                System.Random rnd =
                    new Random((int)DateTime.Now.Ticks);
    
                // Create a list to keep track of which indexes we've
                // already returned
                List<int> visited =
                    new List<int>();
    
                // loop until we've returned the value of all indexes
                // in the list
                while (visited.Count < list.Count)
                {
                    int index =
                        rnd.Next(0, list.Count);
    
                    // Make sure we've not returned it already
                    if (!visited.Contains(index))
                    {
                        visited.Add(index);
                        yield return list[index];
                    }
                }
            }
        }
    }
