    using System;
    using System.Threading.Tasks;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		Console.WriteLine("Foo");
            // prevent the program from exiting until 
            // after the async task(s) have completed.
    		Test().GetAwaiter().GetResult();
    		Console.WriteLine("Baz");
    	}
    
    	static async Task Test()
    	{
    		await SyncADToDBAsync();
    	}
    
    	static async Task SyncADToDBAsync()
    	{
            // for the sake of this example,
    		// emulate the non-blocking call to the HttpClient
    		await Task.Delay(1000);
    		Console.WriteLine("Bar");
    	}
    }
