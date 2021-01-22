    public static object FirstOrDefault( this IEnumerable sequence )
    {
        if( sequence == null ) return null;
        using( var iter = sequence.GetEnumerator() )
        {
            if( iter.MoveNext() )
                return iter.Current;
            return null;
        }
    }
