        public static string[] SplitAndKeepDelimiter(this string input, string delimiter)
        {
            MatchCollection matches = Regex.Matches(input, @"[^" + delimiter + "]+(" + delimiter + "|$)", RegexOptions.Multiline);
            string[] result = new string[matches.Count];
            for (int i = 0; i < matches.Count ; i++)
            {
                result[i] = matches[i].Value;
            }
            return result;
        }
