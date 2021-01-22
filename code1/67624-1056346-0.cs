    public static Exception
    {
    
    	[Conditional("DEBUG")]
    	public static void DumpException( this Exception ex )
    	{
    		Console.WriteLine( ex.ToString() );
    	}
    }
