    public static IEnumerable<T> MultisetIntersect(this IEnumerable<T> first,
        IEnumerable<T> second, IEqualityComparer<T> comparer)
    {
        // Call the overload with the default comparer.
        return first.MultisetIntersect(second, EqualityComparer<T>.Default);
    }
    
    public static IEnumerable<T> MultisetIntersect(this IEnumerable<T> first,
        IEnumerable<T> second, IEqualityComparer<T> comparer)
    {
        // Validate parameters.  Do this separately so check
        // is performed immediately, and not when execution
        // takes place.
        if (first == null) throw new ArgumentNullException("first");
        if (second == null) throw new ArgumentNullException("second");
        if (comparer == null) throw new ArgumentNullException("comparer");
    
        // Defer execution on the internal
        // instance.
        return first.MultisetIntersectImplementation(second, comparer);
    }
    
    private static IEnumerable<T> MultisetIntersectImplementation(
        this IEnumerable<T> first, IEnumerable<T> second, 
        IEqualityComparer<T> comparer)
    {
        // Validate parameters.
        Debug.Assert(first != null);
        Debug.Assert(second != null);
        Debug.Assert(comparer != null);
    
        // Get the dictionary of the first.
        IDictionary<T, long> counts = first.GroupBy(t => t, comparer).
            ToDictionary(g => g.Key, g.LongCount(), comparer);
    
        // Scan 
        foreach (T t in second)
        {
            // The count.
            long count;
        
            // If the item is found in a.
            if (counts.TryGetValue(t, out count))
            {
                // This is positive.
                Debug.Assert(count > 0);
        
                // Yield the item.
                yield return t;
        
                // Decrement the count.  If
                // 0, remove.
                if (--count == 0) counts.Remove(t);
            }
        }
    }
