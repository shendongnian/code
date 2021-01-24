    var source = {some IEnumerable<T>};
    var count = source.Count();
    source.Select( ( item, i ) => TransformFoo( item, i, count ) );
    public static Bar TransformFoo( Foo item, int index, int totalItems )
    {
        if( 0 == index )
        {
            // first item handling
        }
        else if( ( index + 1 ) == totalItems )
        {
            // last item handling
        }
        else
        {
            // default item handling
        }
    }
