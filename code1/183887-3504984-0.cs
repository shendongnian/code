    using System;
    using System.Text.RegularExpressions;
    
    namespace Stackoverflow.Test
    {
        static class Test
        {
            private static readonly Regex regWords = new Regex("\\w+", RegexOptions.Compiled);
    
            static void Main()
            {
                Console.WriteLine("The quick brown fox jumped over the lazy dog".SmartTrim(8));
                Console.WriteLine("The quick brown fox jumped over the lazy dog".SmartTrim(20));
                Console.WriteLine("Hello, I am attempting to build a string extension method to trim a string to a certain length but with not breaking a word. I wanted to check to see if there was anything built into the framework or a more clever method than mine".SmartTrim(100));
            }
    
            public static string SmartTrim(this string s, int length)
            {
                var matches = regWords.Matches(s);
                foreach (Match match in matches)
                {
                    if (match.Index + match.Length > length)
                    {
                        int ln = match.Index + match.Length > s.Length ? s.Length : match.Index + match.Length;
                        return s.Substring(0, ln);
                    }
                }
                return s;
            }
        }
    }
