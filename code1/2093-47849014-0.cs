    static Mutex m = null;
    
    static void Main(string[] args)
    {
    	const string mutexName = "YourApplicationNameHere";
    	bool createdNew = false;
    
    	try
    	{
    		// Initializes a new instance of the Mutex class with a Boolean value that indicates 
    		// whether the calling thread should have initial ownership of the mutex, a string that is the name of the mutex, 
    		// and a Boolean value that, when the method returns, indicates whether the calling thread was granted initial ownership of the mutex.
    
    		using (m = new Mutex(true, mutexName, out createdNew))
    		{
    			if (!createdNew)
    			{
    		    	Console.WriteLine("instance is alreday running... shutting down !!!");
    				Console.Read();
    				return; // Exit the application
    			}
    
    			// Run your windows forms app here
    			Console.WriteLine("Single instance app is running!");
    			Console.ReadLine();
    		}
    
    	   
    	}
    	catch (Exception ex)
    	{
    
    		Console.WriteLine(ex.Message);
    		Console.ReadLine();
    	}
    }
