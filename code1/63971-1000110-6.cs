    public IEnumerable<int> GetItems( object mayNotBeNull ){
      if( mayNotBeNull == null )
        throw new NullPointerException();
      yield return 7;
    }
    
    // ...
    IEnumerable<int> items = GetItems( null ); // <- This does not throw
    items.GetEnumerators().MoveNext();                    // <- But this does
