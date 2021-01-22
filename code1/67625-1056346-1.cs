    public static Exception
    {
    
    	[Conditional("DEBUG")]
    	public static void Dump( this Exception ex )
    	{
    		Console.WriteLine( ex.ToString() );
    	}
    }
