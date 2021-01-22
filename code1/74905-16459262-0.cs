        public static IEnumerable<TResult> Scanl<T, TResult>(
            this IEnumerable<T> source,
            TResult first,
            Func<TResult, T, TResult> combine)
        {
            using (IEnumerator<T> data = source.GetEnumerator())
            {
                yield return first;
                while (data.MoveNext())
                {
                    first = combine(first, data.Current);
                    yield return first;
                }
            }
        }
