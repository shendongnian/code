    // Stores a private List<T>, only accessible through lock tokens
    //  returned by Read, Write, and UpgradableRead.
    var lockedList = new LockedList<T>( );
 
    using( var r = lockedList.Read( ) ) {
      foreach( T item in r.Reader )
        ...
    }
 
    using( var w = lockedList.Write( ) ) {
      w.Writer.Add( new T( ) );
    }
 
    T t = ...;
    using( var u = lockedList.UpgradableRead( ) ) {
      if( !u.Reader.Contains( t ) )
        using( var w = u.Upgrade( ) )
          w.Writer.Add( t );
    }
