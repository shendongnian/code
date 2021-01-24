    using System;
    using System.Linq;
    using MoreLinq;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                double[] x = new double[20] { 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1 };
    
                var results = x.Select((value, index) => new { value, index })
                    .GroupAdjacent(z => z.value)
                    .Where(z => z.Count() >= 4)
                    .Where(z => z.Key == 0) // it is unclear whether you want to filter for specific values - if so, this is how to do it
                    .Select(z =>
                        new { value = z.Key, firstIndex = z.First().index, lastIndex = z.Last().index })
                    .ToList();
    
                Console.WriteLine(string.Join(Environment.NewLine, results.Select(z => $"{z.value} - {z.firstIndex} - {z.lastIndex}")));
                Console.ReadLine();
            }
        }
    }
