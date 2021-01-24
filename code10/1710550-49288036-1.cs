    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                var generated = 0;
                var random = new Random();
                var items = new Dictionary<int, int>();
                for (int i = 0; i < 2400; i++)
                {
                    var number = random.Next(1, 50);
                    generated++; // Keep track of how many have been generated
                    if (items.ContainsKey(number))
                    {
                        // If the number is not unique, increase its appearances by 1
                        items[number]++;
                    }
                    else
                    {
                        // If the number is unique, set its appearances to 1
                        items.Add(number, 1);
                    }
                }
                Console.WriteLine("Number of generated items: " + generated);
                Console.WriteLine("Unique items number: " + items.Count);
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Key} = {item.Value}");
                }
                var highestFive = items
                    // Sort the items by their appearances (highest first)
                    .OrderByDescending(item => item.Value)
                    // Only keep the first 5 items
                    .Take(5);
                Console.WriteLine("Numbers with the highest 5 occurrences");
                foreach (var item in highestFive)
                {
                    Console.WriteLine(item.Key);
                }
            }
        }
    }
