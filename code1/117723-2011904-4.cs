    public static class MyCollectionExtensionMethods
    {
        public static IEnumerable<IEnumerable<TResult>> Rotate<TOrig, TResult>(
            this IEnumerable<TOrig> collection, 
            params Func<TOrig, TResult>[] valueSelectors)
        {
            foreach (var selector in valueSelectors)
            {
                yield return collection.Select(i => selector(i)).ToArray();
            }
        }
    }
