    static IEnumerable<T> Zip<T>(this IEnumerable<T> left,
        IEnumerable<T> right)
    {
        using (var iter = right.GetEnumerator())
        {
            // consume everything in the first sequence
            foreach (var item in left)
            {
                yield return item;
                 
                // and add an item from the second sequnce each time (if we can)
                if (iter.MoveNext())
                {
                    yield return iter.Current;
                }
            }
            // any remaining items in the second sequence
            if (iter.MoveNext())
            {
                yield return iter.Current;
            }                
        }            
    }
    static bool SequenceEqual<T>(this IEnumerable<T> left,
        IEnumerable<T> right)
    {
        var comparer = EqualityComparer<T>.Default;
        using (var iter = right.GetEnumerator())
        {
            foreach (var item in left)
            {
                if (!iter.MoveNext()) return false; // first is longer
                if (!comparer.Equals(item, iter.Current))
                    return false; // item different
            }
            if (iter.MoveNext()) return false; // second is longer
        }
        return true; // same length, all equal            
    }
