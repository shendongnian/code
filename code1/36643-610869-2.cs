    for( int i = 0; i <= items.Length; ++i ) {
      Console.WriteLine( "Window size {0}:", i );
      foreach( string[] window in IterTools<string>.Window( items, i ) )
        Console.WriteLine( string.Join( ", ", window ) );
      Console.WriteLine( );
    }
