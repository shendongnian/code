    using System;
    using System.Threading;
    using System.Threading.Tasks;
    					
    public class Program
    {
    	public static async Task Main()
    	{
    		using (var cts = new CancellationTokenSource())
    		{
    			var task = Task.CompletedTask
    			.ContinueWith(t => Console.WriteLine("Run after completed"))
    			.ContinueWith(t => throw new Exception("Blow up"))
    			.ContinueWith(t => Console.WriteLine("Run after exception"))
    			.ContinueWith(t => cts.Cancel())
    			.ContinueWith(t => Console.WriteLine("This will never be hit because we have been cancelled"), cts.Token)
    			.ContinueWith(t => Console.WriteLine("Run after cancelled."));
    			
    			await task;
    		}
    	}
    }
