    [Flags]
    public enum StreamPosition
    {
       First = 1, Last = 2
    }
    
    public static IEnumerable<R> MapWithPositions<T, R> (this IEnumerable<T> stream, 
        Func<StreamPosition, T, R> map)
    {
        using (var enumerator = stream.GetEnumerator ())
        {
            if (!enumerator.MoveNext ()) yield break ;
            var cur   = enumerator.Current   ;
            var flags = StreamPosition.First ;
            while (true)
            {
                if (!enumerator.MoveNext ()) flags |= StreamPosition.Last ;
                yield return map (flags, cur) ;
                if ((flags & StreamPosition.Last) != 0) yield break ;
                cur   = enumerator.Current ;
                flags = 0 ;
            }
        }
    }
