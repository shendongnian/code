    using System;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
            // use GetAwaiter().GetResult() to prevent
            // the program from exiting until after
            // the async task(s) have completed.
    		Test().GetAwaiter().GetResult();
    	}
    
    	static async Task Test()
    	{
    		await SyncADToDBAsync();
    	}
    
    	static async Task SyncADToDBAsync()
    	{
            // for the sake of this example,
            // we are using Task.Delay(ms) to
    		// emulate the non-blocking call to the HttpClient
    		await Task.Delay(1000);
     		Console.WriteLine("Do something with the response.");
    	}
    }
