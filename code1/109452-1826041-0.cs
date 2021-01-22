    public static class ExtensionOperations
    {
        public static IEnumerable<string> AlphaLengthWise(
            this IEnumerable<string> names)
        {
            if(names == null)
                throw new ArgumentNullException("names");
    
            return names.OrderBy(a => a.Length).ThenBy(a => a);
        }
    }
