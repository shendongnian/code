    public static class Extensions
    {
        public static string ToString(this IEnumerable<string> list, string separator)
        {
            string result = string.Join(separator, list);
            return result;
        }
    }
