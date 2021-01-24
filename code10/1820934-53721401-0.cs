    public static class MyExtensions
    {
        public static IEnumerable<T> SkipButOneWhile<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using (var e = source.GetEnumerator())
            {
                var hasLeading = false;
                var leading = default(T);
                T current;
                while (true)
                {
                    if (!e.MoveNext()) yield break;
                    current = e.Current;
                    if (predicate(current))
                    {
                        hasLeading = true;
                        leading = current;
                    }
                    else
                        break;
                }
                if (hasLeading)
                    yield return leading;
                yield return current;
                while (e.MoveNext())
                    yield return e.Current;
            }
        }
    }
