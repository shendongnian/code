            const string stringToTest = "abcedfghijklghmnopqghrstuvwxyz";
            const string patternToMatch = "gh*";
            Regex regex = new Regex(patternToMatch, RegexOptions.Compiled);
            MatchCollection matches = regex.Matches(stringToTest); 
            foreach (Match match in matches )
            {
                Console.WriteLine(match.Index);
            }
