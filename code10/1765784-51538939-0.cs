    public class Program
    {
	    public static async void Main()
	    {
	    	await TestAsync();
	    }
	
	    private static async Task TestAsync() 
	    {
	    	await Task.Delay(5000);
	    }
    }
