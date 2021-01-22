    var output = new StringBuilder();
    var digitCount = 0;
    foreach( var c in input )
    {
      if( char.IsDigit( c ) )
      {
        output.Append( c );
        digitCount++;
        if( digitCount % 3 == 0 )
        {
          output.Append( "-" );
        }
      }
    }
    // Remove possible last -
    if( output[output.Length - 1] == "-" )
    {
      output.Remove[output.Length - 1, 1];
    }
