    public static class StringExtention
    {
        public static string clean(this string s)
        {
            return (new StringBuilder(s)).Replace("&", "and").Replace(",", "")
                 .Replace("  ", " ").Replace(" ", "-").Replace("'", "")
                 .Replace(".", "").Replace("eacute;", "é").ToString().ToLower();
        }
    }
