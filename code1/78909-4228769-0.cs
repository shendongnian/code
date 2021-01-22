    public static void M1()
    {
        Interlocked.Exchange( ref needsToBeThreadSafe, RandomNumber() );
    }
    
    public static void M2()
    {
        print( Interlocked.Read( ref needsToBeThreadSafe ) );
    }
