    public static class ExtensionMethods
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item)
        {
            return source.Concat(new[] { item });
        }
        public static IEnumerable<T> SkipFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            bool skipped = false;
            foreach (var item in source)
            {
                if (!skipped && predicate(item))
                {
                    skipped = true;
                    continue;
                }
                yield return item;
            }
        }
        public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> source, int index)
        {
            return source.Where((it, i) => i != index);
        }
        public static IEnumerable<T> InsertAt<T>(this IEnumerable<T> source, int index, T item)
        {
            int i = 0;
            foreach (var it in source)
            {
                if (i++ == index)
                    yield return item;
                yield return it;
            }
        }
        public static IEnumerable<T> ReplaceAt<T>(this IEnumerable<T> source, int index, T item)
        {
            return source.Select((it, i) => i == index ? item : it);
        }
    }
