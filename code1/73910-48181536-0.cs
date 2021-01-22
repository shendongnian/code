    internal static class EnumerableExtensions
    {
        internal static IEnumerable<(T1, T2)> EnumerateWith<T1, T2>(this IEnumerable<T1> first, IEnumerable<T2> second)
        {
            using (var firstEnumerator = first.GetEnumerator())
            using (var secondEnumerator = second.GetEnumerator())
            {
                while(firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                {
                    yield return (firstEnumerator.Current, secondEnumerator.Current);
                }
            }
        }
    }
