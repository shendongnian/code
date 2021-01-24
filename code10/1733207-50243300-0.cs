    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<string>
            {
                "Company XXXXXXX",
                "YYYYYY Incorporated",
                "Comp ZZ Inc.",
                "Com AAA BB",
                "StackOverflow",
                "Stack Overflow",
            };
            
            foreach (var worksheetName in GetWorksheetNames(data))
            {
                Console.WriteLine(worksheetName);
            }
        }
    
        private static IEnumerable<string> GetWorksheetNames(IEnumerable<string> data)
        {
            const string worksheetPrefix = "Planning Setup Sheet";
            const int maxWorksheetLength = 31;
    
            var commonWords = new List<string>
            {
                "Com",
                "Comp",
                "Company",
                "Inc",
                "Inc.",
                "Incorporated",
            };
    
            foreach (var item in data)
            {
                var acceptedWords = new List<string>
                {
                    worksheetPrefix
                };
    
                var words = item.Split(' ');
    
                acceptedWords.AddRange(words.Where(word => !commonWords.Contains(word, StringComparer.OrdinalIgnoreCase)));
    
                var initialWorksheetName = string.Join(" ", acceptedWords);
                var finalWorksheetName = initialWorksheetName.Substring(0, Math.Min(initialWorksheetName.Length, maxWorksheetLength));
    
                yield return finalWorksheetName;
            }
        }
    }
