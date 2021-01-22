    public static class StringExtensions
    {
        public static bool ContainsAny(this string input, IEnumerable<string> containsKeywords, StringComparison comparisonType)
        {
            return needles.Any(needle => haystack.IndexOf(needle, comparisonType) >= 0);
        }
    }
