        public static string DecodeQuotedPrintables(string input)
        {
            var occurences = new Regex(@"=[0-9A-H]{2}", RegexOptions.Multiline);
            var matches = occurences.Matches(input);
            var uniqueMatches = new HashSet<string>(matches);
            foreach (string match in uniqueMatches)
            {
                char hexChar= (char) Convert.ToInt32(match.Substring(1), 16);
                input =input.Replace(match, hexChar.ToString());
            }
            return input.Replace("=\r\n", "");
        }       
