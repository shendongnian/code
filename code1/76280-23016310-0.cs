    public static class StringExtensions
    {
        public static string ToProper(this string s)
        {
            return new string(s.CharsToTitleCase().ToArray());
        }
        public static IEnumerable<char> CharsToTitleCase(this string s)
        {
            bool newWord = true;
            foreach (char c in s)
            {
                if (newWord) { yield return Char.ToUpper(c); newWord = false; }
                else yield return Char.ToLower(c);
                if (c == ' ') newWord = true;
            }
        }
    }
