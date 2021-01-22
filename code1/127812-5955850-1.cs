        public static string DecodeQuotedPrintables(string input)
        {
            var occurences = new Regex(@"=[0-9A-H]{2}", RegexOptions.Multiline);
            var matches = occurences.Matches(input);
            foreach (Match match in matches)
            {
                char hexChar= (char) Convert.ToInt32(match.Groups[0].Value.Substring(1), 16);
                input =input.Replace(match.Groups[0].Value, hexChar.ToString());
            }
            return input.Replace("=\r\n", "");
        }       
