    public static IEnumerable<TSource> DuplicatesBy<TSource, TKey>
        (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
    {
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        foreach (TSource element in source)
        {
            // Yield it if the key hasn't actually been added - i.e. it
            // was already in the set
            if (!seenKeys.Add(keySelector(element)))
            {
                yield return element;
            }
        }
    }
