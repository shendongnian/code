            string input = @"oaaawaala";
            string word = "Owl";
            if (Regex.IsMatch(input, Regex.Escape(word), RegexOptions.IgnoreCase))
            {
                MatchCollection matches = Regex.Matches(input, Regex.Escape(word), RegexOptions.IgnoreCase);
                Console.WriteLine("Found: {0}", matches[0].Groups[0].Value);
            }
