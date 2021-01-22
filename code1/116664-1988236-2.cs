    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        static void Main(string[] args)
        {
            string[] tests = {
                "[A-Z,S,3][A-Za-z0-9,D,4]",
                "[A-Z,S,3]aaaa[A-Za-z0-9,D,4]",
                "crap[A-Z,S,3][A-Za-z0-9,D,4]",
                "[A-Z,S,3][]",
                "[A-Z,S,3][klm,D,4][0-9,S,1]"
            };
    
            string segmentRegex = @"\[([^],]+,[SD],\d)\]";
            string lineRegex = @"^(" + segmentRegex + ")+$";
    
            foreach (string test in tests)
            {
                bool isMatch = Regex.Match(test, lineRegex).Success;
                if (isMatch)
                {
                    Console.WriteLine("Successful match: " + test);
                    foreach (Match match in Regex.Matches(test, segmentRegex))
                    {
                        Console.WriteLine(match.Groups[1]);
                    }
                }
            }
        }
    }
