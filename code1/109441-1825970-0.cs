    public static class ExtensionOperstion
    {
        public static IEnumerable<T> AplhaLengthWise<T>(
            this IEnumerable<T> names, Func<T, int> lengthProvider)
        {
            return names
                .OrderBy(a => lengthProvider(a))
                .ThenBy(a => a).ToArray();
        }
    }
