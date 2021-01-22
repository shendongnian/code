    public IEnumerable<int> YieldInts()
    {
    	for (int i = 0; i < 1000; i++)
    	{
    		Thread.Sleep(1000) // or do some other work
    		yield return i;
    	}
    }
    
    public void Main()
    {
    	foreach(int i in YieldInts())
    	{
    		Console.WriteLine(i);
    		if(i == 42)
    		{
    			break;
    		}
    	}
    }
