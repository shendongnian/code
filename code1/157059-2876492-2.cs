    var sb = new StringBuilder();
    foreach( var c in input )
    {
      if( char.IsDigit( c ) )
      {
        sb.Append( c );
      }
    }
    // continue with parsing to int ...
