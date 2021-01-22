      int[] a = { 1, 201, 354 };
      int[] b = { 404, 201, 354 };
    
      int[] c = new int[ 4 ];
      // Start by just copying over one of the arrays completely.
      a.CopyTo( c, 0 );
      // Loop through b and compare each number against each
      // each number in a.
      foreach( int i in b )
      {
        // Assume that you're not dealing with a duplicate
        bool found = true;
        foreach( int j in a )
        {
          // If you find a duplicate, set found to false
          if( i == j )
          {
            found = false;
          }           
        }
        // If you haven't found a duplicate this is the
        // number you want - add it to the array.
        if (found == true)
        {
          c[3] = i;
        }
      }
