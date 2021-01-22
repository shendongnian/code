    public static void Main()
    {
    	try
    	{
    		Console.WriteLine("Before throwing");
    		throw new Exception("Exception!");
    	}
    	finally
    	{
    		Console.WriteLine("In finally");
    		Console.ReadLine();
    	}
    }
