    public static class ExtensionOperstion
    {
        public static IEnumerable<T> AlphaLengthWise<T, L>(
            this IEnumerable<T> names, Func<T, L> lengthProvider)
        {
            return names
                .OrderBy(a => lengthProvider(a))
                .ThenBy(a => a);
        }
    }
