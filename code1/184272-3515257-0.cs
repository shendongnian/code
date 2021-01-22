    using System;
    using System.Collections.Generic;
    namespace CSharpSandbox
    {
        class Program
        {
            static IEnumerable<T> Where<T>(IEnumerable<T> input, Func<T, bool> predicate)
            {
                foreach (T item in input)
                {
                    if (predicate(item))
                        yield return item;
                }
            }
    
            static void Main(string[] args)
            {
                int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                IEnumerable<int> evens = Where(numbers, n => n % 2 == 0);
                foreach (int even in evens)
                {
                    Console.WriteLine(even);
                }
            }
        }
    }
