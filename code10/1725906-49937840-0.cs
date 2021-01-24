    using System;
    using System.Linq;
    using MoreLinq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int[,] array =
                {
                    { 0, 1,  2,  3 },
                    { 4, 5,  6,  7 },
                    { 8, 9, 10, 11 }
                };
                foreach (var row in array.Cast<int>().Batch(array.GetLength(1)))
                {
                    Console.WriteLine(string.Join(";", row));
                }
            }
        }
    }
