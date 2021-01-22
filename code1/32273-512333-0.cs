      Type T = l.GetType ( ).GetGenericArguments ( ) [ 0 ];
      ConstructorInfo ctor = T.GetConstructor (
        new Type [ 2 ] { typeof ( int ), typeof ( string ) } );
      System.Diagnostics.Debug.Assert ( ctor != null );
      object instance = ctor.Invoke (
        new object [ 2 ] { 0, "None" } );
