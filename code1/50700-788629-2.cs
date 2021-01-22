    [Flags]
    public enum StreamPosition
    {
       First = 1, Last = 2
    }
    
    public static IEnumerable<KeyValuePair<StreamPosition, T>> WithPositions<T> (
        IEnumerable<T> stream)
    {
        using (var enumerator = stream.GetEnumerator ())
        {
            if (!enumerator.MoveNext ()) yield break ;
            var cur   = enumerator.Current   ;
            var flags = StreamPosition.First ;
            while (true)
            {
                if (!enumerator.MoveNext ()) flags |= StreamPosition.Last ;
                yield return new KeyValuePair<T, StreamPosition> (flags, cur) ;
                if ((flags & StreamPosition.Last) != 0) yield break ;
                cur   = enumerator.Current ;
                flags = 0 ;
            }
        }
    }
