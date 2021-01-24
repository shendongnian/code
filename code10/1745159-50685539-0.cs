        string input = "abc {string 1} def {string 2}{string 3}";
        string pattern = "(({).+?(}))";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        
        MatchCollection matches = rgx.Matches(input);
        if (matches.Count > 0)
        {
            Console.WriteLine("{0} ({1} matches):", input, matches.Count);
            foreach (Match match in matches)
                Console.WriteLine("   " + match.Value);
        }
