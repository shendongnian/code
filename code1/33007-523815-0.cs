    public static class RegexExtensions
    {
        public static bool Match(this string text, Regex re)
        {
            return Regex.Match(text, re);
        }
    }
