    public delegate A AggregateAction<A, B>( A prevResult, B currentElement );
    public static Tagg Aggregate<Tcoll, Tagg>( 
        IEnumerable<Tcoll> source, Tagg seed, AggregateAction<Tagg, Tcoll> func )
    {
        Tagg result = seed;
        foreach ( Tcoll element in source ) 
            result = func( result, element );
			
        return result;
    }
    //this makes max easy
    public static int Max( IEnumerable<int> source )
    {
        return Aggregate<int,int>( source, 0, 
            delegate( int prev, int curr ) { return curr > prev ? curr : prev; } );
    }
    //but you could also do sum
    public static int Sum( IEnumerable<int> source )
    {
        return Aggregate<int,int>( source, 0, 
            delegate( int prev, int curr ) { return curr + prev; } );
    }
