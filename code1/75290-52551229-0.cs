    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, T> operation)
        {
            return Merge<T, T, T>(first, second, operation);
        }
        public static IEnumerable<TResult> Merge<T, TResult>(this IEnumerable<T> first, IEnumerable<T> second, Func<T, T, TResult> operation)
        {
            return Merge<T, T, TResult>(first, second, operation);
        }
        public static IEnumerable<TResult> Merge<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> operation)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));
            using (var iter1 = first.GetEnumerator())
            using (var iter2 = second.GetEnumerator())
            {
                while (iter1.MoveNext())
                {
                    yield return iter2.MoveNext()
                        ? operation(iter1.Current, iter2.Current)
                        : operation(iter1.Current, default);
                }
                while (iter2.MoveNext())
                {
                    yield return operation(default, iter2.Current);
                }
            }
        }
    }
