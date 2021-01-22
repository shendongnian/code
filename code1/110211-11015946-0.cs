    /**
     * Returns the service name of currently running windows service.
     */
    static String getServiceName()
    {
    	ServiceController[] scServices;
    	scServices = ServiceController.GetServices();
    
    	// Display the list of services currently running on this computer.
    	int my_pid = System.Diagnostics.Process.GetCurrentProcess().Id;
    
    	foreach (ServiceController scTemp in scServices)
    	{
    		// Write the service name and the display name
    		// for each running service.
    
    		// Query WMI for additional information about this service.
    		// Display the start name (LocalSytem, etc) and the service
    		// description.
    		ManagementObject wmiService;
    		wmiService = new ManagementObject("Win32_Service.Name='" + scTemp.ServiceName + "'");
    		wmiService.Get();
    
    		int id = Convert.ToInt32(wmiService["ProcessId"]);
    		if (id == my_pid)
    		{
    			return scTemp.ServiceName;
    #if IS_CONSOLE
    			Console.WriteLine();
    			Console.WriteLine("  Service :        {0}", scTemp.ServiceName);
    			Console.WriteLine("    Display name:    {0}", scTemp.DisplayName);
    
    			Console.WriteLine("    Start name:      {0}", wmiService["StartName"]);
    			Console.WriteLine("    Description:     {0}", wmiService["Description"]);
    		
    			Console.WriteLine("    Found.......");
    #endif
    		}
    	}
    	return "NotFound";
    }
