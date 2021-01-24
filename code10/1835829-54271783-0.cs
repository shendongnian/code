    using System;
    using System.Collections.Generic;
    
    namespace Test
    {
        public class Program
        {
            public static IEnumerable<int> RemoveDuplicates(int[] input)
            {
                int? old = null;
    
                foreach (var value in input)
                {
                    if (value != old)
                        yield return value;
    
                    old = value;
                }
            }
    
            public static void Main()
            {
                int[] getallen = new int[] { 1, 1, 2, 2, 3, 4, 4, 4, 5, 6 };
                Console.WriteLine(string.Join(",", RemoveDuplicates(getallen)));
    
                Console.ReadLine();
            }
        }
    }
