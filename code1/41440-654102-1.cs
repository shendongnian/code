    public static class Extensions
    {
        public static string JoinWith(this IEnumerable<string> strings, string separator)
        {
            return String.Join(separator, strings.ToArray());
        }
    }
