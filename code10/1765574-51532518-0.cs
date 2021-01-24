    public static class MyStringExtensions
    {
        public static bool Like(this string toSearch, string toFind)
        {
            Regex findRegex = new Regex(Regex.Escape(toFind).Replace("%", ".*"));
            return findRegex.IsMatch(toSearch);
        }
    }
