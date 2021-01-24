    class Program
    {
    	static async Task Main(string[] args)
    	{
    
    		Program.Closed += Program.HubOnClosed;
    		Observable.FromEvent<Func<Exception, Task>, Exception>(
    			a => e => {a(e); return Task.CompletedTask; }, 
    			h => Program.Closed += h, 
    			h => Program.Closed -= h
    		)
    			.Subscribe(e =>
    			{
    				Console.WriteLine("Rx: The connection to the hub has been closed");
    			});
    
    		Program.Closed.Invoke(null);
    		Program.Closed.Invoke(null);
    	}
    
    	private static Task HubOnClosed(Exception arg)
    	{
    		Console.WriteLine("The connection to the hub has been closed");
    		return Task.CompletedTask;
    	}
    
    	public static event Func<Exception, Task> Closed;
    }
