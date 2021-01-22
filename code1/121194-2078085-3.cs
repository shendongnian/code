    public static IEnumerable<TSource> OrderByTop<TSource, TKey>(
        IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer,
        int topCount)
    {
        // allocate enough space to hold the number of elements (+1 as a new candidate is added)
        FibonacciHeap<TKey,TSource> top = new FibonacciHeap<TKey,TSource>( comparer );
        foreach (var candidate in source) // O(n)
        {
             TKey key = keySelector(candidate);
             TKey minimum = top.AccessMinimum();
             if (minimum == null || comparer.Compare( key, minimum.Key ) > 0) // O(1)
             {
                 top.Insert( key, candidate ); // O(1)
                 if (top.Count >= topCount)
                 {
                     top.DeleteMinimum(); // O(logk)
                 }
             }
        }
        return top.ToList().Reverse().Select( t.Value ); // O(k)   
    }
