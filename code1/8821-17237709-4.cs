    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> SelectManyRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            foreach (T item in source)
            {
                yield return item;
            
                var children = selector(item);
                if (children == null)
                    continue;
            
                foreach (T descendant in children.SelectManyRecursive(selector))
                {
                    yield return descendant;
                }
            }
        }
    }
