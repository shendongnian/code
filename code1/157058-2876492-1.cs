    var digitCount = 0;
    for( var i = input.Length - 1; i >= 0; i++ )
    {
      if( char.IsDigit( input[i] )
      {
        sb.Insert( 0, input[i] );
        digitCount++;
        if( digitCount % 3 == 0 )
        {
           sb.Insert( 0, "-" );
        }
      }
    }
