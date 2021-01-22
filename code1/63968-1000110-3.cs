    public IEnumerable<int> GetItems( object mayNotBeNull ){
      if( mayNotBeNull == null )
        throw new NullPointerException();
      // other quick checks
      return GetItemsCore( mayNotBeNull );
    }
    private IEnumerable<int> GetItemsCore( object mayNotBeNull ){
      SlowRunningMethod();
      CallToDatabase();
      // etc
      yield return 7;
    }    
    // ...
    IEnumerable<int> items = GetItems( null ); // <- Now this will throw
