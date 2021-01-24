    public class Program
    {
	  public static void Main()
	  {	
		CancellationTokenSource source = new CancellationTokenSource();
      	CancellationToken token = source.Token;
		var task=AsyncMain(token);
		source.Cancel();
		try
		{
		Console.WriteLine("Main after started thread");
		task.Wait();
		Console.WriteLine("Main after task finished");
		}
		catch (AggregateException )
		{
		Console.WriteLine("Exceptions in Task");
		}
	  }
	
	  public static async Task AsyncMain(CancellationToken token)
	  {
		Console.WriteLine("In Thread at Start");
		try
		{
		  await Task.Delay(10).ContinueWith(
            async task =>
		    {
    		  Console.WriteLine("Not Cancelled");
		    }
		    ,token);
		}
		catch(TaskCanceledException)
		{
          Console.WriteLine("Cancelled");
        }
		Console.WriteLine("In Thread after Task");
	  }
    }
