    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    namespace StackOverflow
    {
        public class StringMatch
        {
            public Dictionary<string, string> Matches = new Dictionary<string, string>
            {
                { "first_match", "One" },
                { "second_match", "Two" },
                { "third_match", "Three" },
                { "fourth_match", "Four!" },
                { "fifth_match", "Five" }
            };
            public List<string> Strings = new List<string>
            {
                "001_first_match",
                "010_second_match",
                "011_third_match"
            };
            [Test]
            public void FindMatches()
            {
                foreach (var item in Strings)
                {
                    foreach (var match in Matches)
                    {
                        if (item.Contains(match.Key))
                        {
                            Console.WriteLine(match.Value);
                            break;
                        }
                    }
                }
            }
        }
    }
