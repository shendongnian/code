    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                List<int> list = Enumerable.Range(1, 10).ToList();
                for (int i = 0; i < list.Count; ++i)
                {
                    if ((list[i] % 3) == 0) // Remove multiples of 3.
                        list.RemoveAt(i--); // NOTE: Post-decrement i
                    else if ((list[i] % 4) == 0) // At each multiple of 4, add (2*value+1)
                        list.Add(list[i] * 2 + 1);
                    else
                        ; // Do nothing.
                }
                Console.WriteLine(string.Join(", ", list)); // Outputs 1, 2, 4, 5, 7, 8, 10, 17
            }
        }
    }
