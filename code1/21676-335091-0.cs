    public static class StringExtensions
    {
        public static string StripIncompatableQuotes(this string s)
        {
            if (!string.IsNullOrEmpty(s))
                return s.Replace('\u2018', '\'').Replace('\u2019', '\'');
            else
                return s;
        }
    }
