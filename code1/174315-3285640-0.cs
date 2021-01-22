    public static class OuterClass
    {
    	public static int GetNumber()
    	{
    		return 1;
    	}
    	
    	public static string GetString()
    	{
    		return "Hello, World!";
    	}
    }
    
    public class Program
    {
    	private static class InnerClass
    	{
    		public static int GetNumber()
    		{
    			return 1;
    		}
    		
    		public static string GetString()
    		{
    			return "Hello, World!";
    		}
    	}
    	
    	const int N = 1000000;
    	
    	public static void Main()
    	{
    		var sw = Stopwatch.StartNew();
    		for (int i = 0; i < N; ++i)
    		{
    			int x = OuterClass.GetNumber();
    			string s = OuterClass.GetString();
    		}
    		sw.Stop();
    		
    		TimeSpan outerTime = sw.Elapsed;
    		
    		sw.Reset();
    		sw.Start();
    		for (int i = 0; i < N; ++i)
    		{
    			int x = InnerClass.GetNumber();
    			string s = InnerClass.GetString();
    		}
    		sw.Stop();
    		
    		TimeSpan innerTime = sw.Elapsed;
    		
    		Console.WriteLine("Outer took {0:0.00} ms.", outerTime.TotalMilliseconds);
    		Console.WriteLine("Inner took {0:0.00} ms.", innerTime.TotalMilliseconds);
    	}
    }
