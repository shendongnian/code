    static void Main(string[] args)
    {
    	try
    	{
    		ushort var = 65535;
    		try
    		{
    			checked { var++; }
    		}
    		catch (OverflowException)
    		{
    			Console.WriteLine("Hello!");
    			throw;
    		}
    	}
    	catch
    	{
    		Console.WriteLine("Here I am!");
    	}
    }
