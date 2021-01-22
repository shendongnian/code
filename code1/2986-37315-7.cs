    try {
      using( EventWatcher.Create( o, x => x.MyEvent ) ) {
        //o.RaiseEvent( );  // Uncomment for test to succeed.
      }
      Console.WriteLine( "Event raised successfully" );
    }
    catch( InvalidOperationException ex ) {
      Console.WriteLine( ex.Message );
    }
