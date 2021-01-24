    [TestFixture]
    class Program
    {
    
    	static void Main()
    	{
    		Log.Info("test");
    		Console.ReadLine();
    	}
    
    	[Test]
    	public void Test()
    	{
    		Log.Info("test");
    	}
    }
