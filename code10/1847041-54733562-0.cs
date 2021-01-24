    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    class Test
    {
        static void Main()
        {
            string input = "FB:77:CB:0B:EC:09{W: 0,623413, X: 0,015374, Y: 0,005306, Z: -0,781723}";
            var parsed = Parse(input);
            foreach (var entry in parsed)
            {
                Console.WriteLine($"Key = '{entry.Key}', Value = '{entry.Value}'");
            }        
        }
        
        static readonly Regex regex = new Regex(@"(?<key>[A-Z]+): (?<value>[-\d,]+)");
        static IDictionary<string, string> Parse(string input)
        {
            int openBrace = input.IndexOf('{');
            if (openBrace == -1)
            {
                throw new ArgumentException("Expected input to contain a {");
            }
            if (!input.EndsWith("}"))
            {
                throw new ArgumentException("Expected input to end with }");
            }
            string inner = input.Substring(openBrace + 1, input.Length - openBrace - 2);
            var matches = regex.Matches(inner);
            return matches.Cast<Match>()
                .ToDictionary(match => match.Groups["key"].Value,
                              match => match.Groups["value"].Value.TrimEnd(','));
        }
    }
