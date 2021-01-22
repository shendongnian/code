    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source)
    {
        using (IEnumerator<T> iterator = source.GetEnumerator())
        {
            if(!iterator.MoveNext())
            {
                yield break;
            }
            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return previous;
                previous = iterator.Current;
            }
        }
    }
