    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    namespace Demo
    {
        class Program
        {
            public static void Main(string[] args)
            {
                var Matches = new Hashtable
                {
                    {"first_match", "One"},
                    {"second_match", "Two"},
                    {"third_match", "Three"},
                    {"fourth_match", "Four!"},
                    {"fifth_match", "Five"}
                };
                var Targets = new List<string>
                {
                    "001_first_match",
                    "010_second_match",
                    "011_third_match"
                };
                var matches =
                    Matches.Cast<DictionaryEntry>()
                    .Where(x => Targets.Any(s => s.Contains((string)x.Key)))
                    .Select(v => v.Value);
                Console.WriteLine(string.Join("\n", matches)); // Outputs "Three", "One" and "Two".
            }
        }
    }
