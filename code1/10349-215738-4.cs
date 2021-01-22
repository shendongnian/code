<!-- -->
    T t = ...;
    using( var u = lockedList.UpgradableRead( ) ) {
      if( !u.Reader.Contains( t ) )
        using( var w = u.Upgrade( ) )
          w.Writer.Add( t );
    }
