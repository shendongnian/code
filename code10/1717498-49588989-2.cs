    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main()
    	{
    		var tasks = Task.WhenAll(
    			RunTimeLimitedTask(10, 50),
    			RunTimeLimitedTask(1000, 0)
    		);
    		
    		var results = tasks.GetAwaiter().GetResult();
    		foreach(var result in results) 
    		{
    			Console.WriteLine(result);
    		}	
    	}
    
    	public async static Task<string> RunTimeLimitedTask(int timeLimit, int runningTime)
    	{
    		var source = new CancellationTokenSource();
    		source.CancelAfter(timeLimit);
    
    		try {
    			// mimic a web request
    			await Task.Run(async () => await Task.Delay(runningTime, source.Token));
    			return "Complete";
    		}
    		catch (TaskCanceledException) {
    			return "Cancelled";
    		}
    	}
    }
