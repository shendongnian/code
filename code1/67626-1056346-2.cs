    public static Exception
    {
    	public static void Log( this Exception ex )
    	{
    #if DEBUG
    	    Console.WriteLine( ex.ToString() );
    #endif
            Logger.WriteLine( ex.ToString() );
    	}
    }
