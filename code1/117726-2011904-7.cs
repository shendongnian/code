    public static class MyCollectionExtensionMethods
    {
        public static IEnumerable<IEnumerable<TResult>> Rotate<TOrig, TResult>(
            this IEnumerable<TOrig> collection, 
            params Func<TOrig, TResult>[] valueSelectors)
        {
            return valueSelectors.Select(s => collection.Select(i => s(i)));
        }
    }
