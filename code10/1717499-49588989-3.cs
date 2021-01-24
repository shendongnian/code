    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main()
    	{
    		DoIt().GetAwaiter().GetResult();
    	}
    	
    	public async static Task DoIt() 
    	{
    		var results = await Task.WhenAll(
    			RunTimeLimitedTask(10),
    			RunTimeLimitedTask(1000));
    		
    		foreach(var result in results) Console.WriteLine(result);
    	}
    
    	public async static Task<string> RunTimeLimitedTask(int timeLimit)
    	{
    		var source = new CancellationTokenSource();
    		source.CancelAfter(timeLimit);
    
    		try {
    			// mimic a web request that will take 500ms
    			await Task.Run(async () => await Task.Delay(500, source.Token));
    			return "Complete";
    		}
    		catch (TaskCanceledException) {
    			return "Cancelled";
    		}
    	}
    }
