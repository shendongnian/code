    public static IEnumerable<TElement>UniqueBy<TElement, TKey>
        (this IEnumerable<TElement> source,
         Func<TElement, TKey> keySelector)
    {
        // No error checking :)
        HashSet<TKey> uniqueKeys = new HashSet<TKey>();
        HashSet<TKey> seenKeys = new HashSet<TKey>();
        
        foreach (TElement element in source)
        {
            TKey key = keySelector(element);
            if (seenKeys.Add(key))
            {
                uniqueKeys.Add(key);
            }
            else
            {
                uniqueKeys.Remove(key);
            }
        }
        foreach (TElement element in source)
        {
            if (uniqueKeys.Contains(keySelector(element)))
            {
                yield return element;
            }
        }
    }
