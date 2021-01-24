    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            List<string> pieces = SplitToDottedNumbers("1.1.1 sadsajkdn 1.1.2.1 dfkjskf 2.1.1");
            foreach (string piece in pieces)
            {
                Console.WriteLine(piece);
            }
        }
        
        static List<string> SplitToDottedNumbers(string text)
        {
            // Inline for readability. You could create this just once.
            var regex = new Regex(@"\d+(\.\d+)*");
            // LINQ-based implementation
            return regex.Matches(text)
                .Cast<Match>()
                .Select(match => match.Value)
                .ToList();
            /* Alternative implementation
            var pieces = new List<string>();
            var match = regex.Match(text);
            while (match.Success)
            {
                pieces.Add(match.Value);
                match = match.NextMatch();
            }
            return pieces;
            */
        }
    }
