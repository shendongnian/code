    using System;
    using System.Linq;
    
    public class Program
    {
        static void Main()
        {
            Random rng = new Random();
            var letters = Enumerable.Range(0, 50)
                .Select(_ => (char) rng.Next(65,91))
                .ToArray();
            
            Console.WriteLine($"Letters: {new string(letters)}");
            var orderedGroups = letters
                .GroupBy(c => c, (c, g) => new { Letter = c, Count = g.Count() })
                .OrderBy(g => g.Key);
                         
            foreach (var element in orderedGroups)
            {
                Console.WriteLine(element);
            }
        }
    }
