    private static IEnumerable<TResult> CastIterator<TResult>( IEnumerable source )
    {
        foreach(object current in source)
        {
            yield return (TResult)( (object)current );
        }
        yield break;
    }
    public static IEnumerable<TResult> DCast<TResult>( this IEnumerable source )
    {
        IEnumerable<TResult> enumerable = source as IEnumerable<TResult>;
        if(enumerable != null)
        {
            return enumerable;
        }
        if(source == null)
        {
            throw new ArgumentNullException( "source" );
        }
        return CastIterator<TResult>( source );
    }
