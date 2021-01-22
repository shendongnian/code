    public static class ExtensionOperation
    {
        public static IEnumerable<String> AplhaLengthWise(
                                       this IEnumerable<String> names)
        {
            return names.OrderBy(a => a.Length).ThenBy(a => a);
        }
    }
