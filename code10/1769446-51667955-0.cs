    public static IEnumerable<T> DistinctUntilChanged<T>(
        this IEnumerable<T> source) 
    {
        using (var e = source.GetEnumerator())
        {
            if (!e.MoveNext())
                yield break;
            
            yield return e.Current;
            var previous = e.Current;
            
            while (e.MoveNext())
            {
                if (!e.Current.Equals(previous))
                    yield return e.Current;
                
                previous = e.Current;
            }
        }
    }
