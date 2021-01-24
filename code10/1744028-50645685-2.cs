    public static class StringWordsExtensions
    {
        public static bool ContainsMultipleTimes(this string input, string word)
        {
            var regex = new Regex(string.Format(@"\b{0}\b", word),
                                  RegexOptions.IgnoreCase);
            return regex.Matches(input).Count > 1;
        }
    }
