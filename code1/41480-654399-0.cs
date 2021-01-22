    SomeType t = new SomeType();
    
    try
    {
       // do some stuff
    }
    finally
    {
       if( t != null ) 
       {
          t.Dispose();
       }
    }
