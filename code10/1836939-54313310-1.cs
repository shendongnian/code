      var best = new List<Ranking>( );
      sorted.ForEach( r1 => 
      {
        if ( !best.Any
        ( 
          r2 => 
            r1.JOB_ID == r2.JOB_ID 
            || 
            r1.EMPLOYEE_ID == r2.EMPLOYEE_ID
        ) )
        {
          best.Add( r1 );
        }
      } );
