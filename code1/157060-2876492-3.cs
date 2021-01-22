    // Parse the input: remove all but digits
    var digits = new StringBuilder();
    foreach( var c in input )
    {
      if( char.IsDigit( c ) )
      {
        digits.Append( c );
      }
    }
    // Insert dashes
    for( var i = 3; i < digits.Length; i += 3 )
    {
      digits.Insert( i, "-" );
    }
