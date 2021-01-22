    public static class ExtensionOperations
    {
        public static IEnumerable<string> AlphaLengthWise(this string[] names)
        {
            var query = names.OrderBy(a => a.Length).ThenBy(a => a);
            return query;
        }
    }
