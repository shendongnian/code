    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int[]    array1 = {1, 2, 3, 4, 5};
                string[] array2 = {"One", "Two", "Three", "Four", "Five"};
                double[] array3 = {0.1, 0.2, 0.3, 0.4, 0.5};
                // Create an array of indices the same length as the arrays to be shuffled.
                var indices = Enumerable.Range(0, array1.Length).ToArray();
                // Shuffle the indices.
                Shuffle(indices, new Random());
                // Now you can use the shuffled indices to access all the arrays in the same random order:
                foreach (int index in indices)
                {
                    Console.WriteLine($"{array1[index]}, {array2[index]}, {array3[index]}");
                }
            }
            // Standard shuffle.
            public static void Shuffle<T>(IList<T> array, Random rng)
            {
                for (int n = array.Count; n > 1;)
                {
                    int k = rng.Next(n);
                    --n;
                    T temp = array[n];
                    array[n] = array[k];
                    array[k] = temp;
                }
            }
        }
    }
