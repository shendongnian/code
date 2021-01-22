    private static void SetTestConnectionString( Component table )
    {
        if( table.GetType() == typeof(Object1) )
        {
            Object1 object1 = (Object1)table;
            fn1( object1 );
        }
        // ... a few more if statements for different Classes
    }
