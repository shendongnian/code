    void Main()
    {	
    	for (int x = 0; x < 10; x++)
    	{
    		ThreadPool.QueueUserWorkItem(z=> myClass.DoSomething());
    	}
    	
    }
    public class myClass
    {
    	public static void DoSomething()
    	{
    		int i = 0;
    		Console.WriteLine (i += 3);
    	}
    }
