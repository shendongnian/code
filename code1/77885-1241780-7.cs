    Validation<Connection> v = ( Connection c ) => ( c != null && !( c.IsBusy || c. IsFull ) );
    Connection bestConnection =
        server1.GetConnection().Validate( v ) ??
        server2.GetConnection().Validate( v ) ??
        server3.GetConnection().Validate( v ) ?? null;
