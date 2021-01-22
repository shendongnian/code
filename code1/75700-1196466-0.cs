    using System;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string[] samples = new[] { "Gorillaz (2001)",
                    "Gorillaz (7th State Mix) (2002)",
                    "Gorillaz (2001) (Featuring Travis)",
                    "Two matches: (2002) (1950)",
                    "Gorillaz (1Mix) (1952)",
                    "Gorillaz (1Mix) (2003)",
                    "Gorillaz (1000) (2001)" };
            
            foreach (string name in samples)
            {
                ShowMatches(name);
            }
        }
        
        static readonly Regex YearRegex = new Regex(@"\((19[5-9]\d|200\d)\)");
        
        static void ShowMatches(string name)
        {
            Console.WriteLine("Matches for: {0}", name);
            foreach (Match match in YearRegex.Matches(name))
            {
                Console.WriteLine(match.Value);
            }
        }
    }
