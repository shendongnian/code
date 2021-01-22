    public static class EnumerableExtensions
    {
        public static IEnumerable<TResult> SelectWithSeparator<T, TResult>(
            this IEnumerable<T> source,
            Func<T, TResult> selector,
            TResult separator)
        {
            if (selector == null)
                throw new ArgumentNullException("selector");
            foreach (T item in source)
            {
                yield return selector(item);
                yield return separator;
            }
        }
    }
