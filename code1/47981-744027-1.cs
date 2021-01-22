    void method1()
    {
        try
        {
            method2( 1 );
        }
        catch( MyCustomException e )
        {
            // put error handling here
        }
 
     }
    int method2( int val )
    {
        if( val == 1 )
           throw new MyCustomException( "my exception" );
        return val;
    }
