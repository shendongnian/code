    public static IEnumerable<T> Intersperse<T>(this IEnumerable<T> source, T element)
    {
        using (var enumerator = source.GetEnumerator()) {
            if (enumerator.MoveNext()) {
                yield return enumerator.Current;
                while (enumerator.MoveNext()) {
                    yield return element;
                    yield return enumerator.Current;
                }
            }
        }
    }
