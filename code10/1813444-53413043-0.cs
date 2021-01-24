    class Dummy
    {
    	public int i = 0;
    	
    	~Dummy()
    	{
    		Console.WriteLine("~Dummy --> " + i);
    	}
    }
