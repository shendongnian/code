    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input = "{ \"do\": \"Thing\", \"with\": \"abc\" }";
                string pattern = "\"(?'key'[^\"]+)\":\\s+\"(?'value'[^\"]+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                Dictionary<string, string> dict = matches.Cast<Match>()
                    .GroupBy(x => x.Groups["key"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
