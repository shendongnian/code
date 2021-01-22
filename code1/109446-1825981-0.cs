    public static class ExtensionOperations
    {
        public static string[] AlphaLengthWise(this string[] names)
        {
            var query = names.OrderBy(a => a.Length).ThenBy(a => a);
            return query.ToArray();
        }
    }
