    public static IEnumerable<TSource> OrderByTop<TSource, TKey>(
        IEnumerable<TSource> source,
        Func<TSource, TKey> keySelector,
        IComparer<TKey> comparer,
        int topCount)
    {
        // allocate enough space to hold the number of elements (+1 as a new candidate is added)
        Dictionary<TKey,TSource> top = new Dictionary<TKey,TSource>( topCount + 1 );
        TKey minimum = null;
        foreach (var candidate in source)
        {
             TKey key = keySelector(candidate);
             if (minimum == null || comparer.Compare( key, minimum ) > 0)
             {
                 top.Add( key, candidate);
                 if (top.Count >= topCount)
                 {
                     top.Remove( minimum );
                     minimum = top.Select( t => t.Key ).Min( comparer );
                 }
             }
        }
        return top.OrderByDescending( t => t.Key, comparer ).Select( t.Value );    
    }
