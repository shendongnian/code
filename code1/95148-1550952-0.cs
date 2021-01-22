    Dictionary<double, Dictionary<double, List<string>>> master
         = new Dictionary<double, Dictionary<double, List<string>>>();
    
    for( double i = 1; i < 5; i += 0.25 )
    {
        master[ i ] = new Dictionary<double, List<string>>();
        for( double j = 1; j < 5; j += 0.25 )
        {
            master[ i ][ j ] = new List<string>();
            master[ i ][ j ].Add( String.Format( "{0}-{1}a", i, j ) );
            master[ i ][ j ].Add( String.Format( "{0}-{1}b", i, j ) );
            master[ i ][ j ].Add( String.Format( "{0}-{1}c", i, j ) );
        }
    }
