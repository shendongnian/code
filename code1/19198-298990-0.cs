        public static IEnumerable<string> SplitCommandLine(string commandLine)
        {
            bool inQuotes = false;
            return commandLine.Split(c =>
                                     {
                                         if (c == '\"')
                                             inQuotes = !inQuotes;
                                         return !inQuotes && c == ' ';
                                     })
                              .Select(arg => arg.Trim().TrimMatchingQuotes('\"'))
                              .Where(arg => !string.IsNullOrEmpty(arg));
        }
