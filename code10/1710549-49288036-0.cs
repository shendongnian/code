    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                var generated = GenerateList();
                var uniqueItems = generated
                    // Groups each number by the given key (itself). Each group will contain one distinct number
                    .GroupBy(x => x)
                    // Creates key/value pairs. The key is the unique number. The value is the number of appearances
                    .ToDictionary(group => group.Key, group => group.Count());
                Console.WriteLine("Number of generated items: " + generated.Count);
                Console.WriteLine("Unique items number: " + uniqueItems.Count);
                foreach (var item in uniqueItems)
                {
                    Console.WriteLine($"{item.Key} = {item.Value}");
                }
                var highestFive = uniqueItems
                    // Sort the items by their appearances (highest first)
                    .OrderByDescending(item => item.Value)
                    // Only keep the first 5 items
                    .Take(5);
                Console.WriteLine("Numbers with the highest 5 occurrences");
                foreach (var item in highestFive)
                {
                    Console.WriteLine(item.Key);
                }
                /* Output:
                 * Number of generated items: 20
                 * Unique items number: 6
                 * 10 = 2
                 * 25 = 3
                 * 30 = 5
                 * 45 = 4
                 * 5 = 5
                 * 15 = 1
                 * Numbers with the highest 5 occurrences
                 * 30
                 * 5
                 * 45
                 * 25
                 * 10
                 */
            }
            private static List<int> GenerateList()
            {
                // For simplicity, using known variables
                // This function could generate any type of list you want
                return new List<int>
                {
                    10, 25, 30, 45, 30, 45, 25, 30, 25, 30, 5, 5, 15, 30, 45, 10, 45, 5, 5, 5
                };
            }
        }
    }
