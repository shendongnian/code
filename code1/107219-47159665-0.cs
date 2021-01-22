    public static IEnumerable<T> SkipLast<T>(this IEnumerable<T> source)
    {
        using (var it = source.GetEnumerator())
        {
            if (it.MoveNext())
            {
                var item = it.Current;
                while (it.MoveNext())
                {
                    yield return item;
                    item = it.Current;
                }
            }
        }
    }
