    public static class StringExtensions
    {
        public static string StripIncompatableQuotes(this string s)
        {
            if (!string.IsNullOrEmpty(s))
                return s.Replace('\u2018', '\'').Replace('\u2019', '\'').Replace('\u201c', '\"').Replace('\u201d', '\"');
            else
                return s;
        }
    }
