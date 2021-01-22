    public static class EnumerableExt
    {
        public static IEnumerable<T> One<T>(T item)
        {
            yield return item;
        }
    }
    ...
    //prepend:
    EnumerableExt.One( GetHeaders() ).Concat( GetData() );
    //append:
    GetData().Concat( EnumerableExt.One( GetHeaders() );
