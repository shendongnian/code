    static class Program
    {
    	/// <summary>
    	/// The main entry point for the application.
    	/// </summary>
    	[STAThread]
    	static void Main()
    	{
    	    ServiceBase[] ServicesToRun;
    	    ServicesToRun = new ServiceBase[] 
    	    { 
    	        new YourService();
    	    };
    	    ServiceBase.Run(ServicesToRun);
    	}
    }
