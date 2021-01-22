    using (DirectoryEntry de = 
            new DirectoryEntry("IIS://Localhost/w3svc/1/root/MyApp"))
    {
    	// Cast our native underlying object to the correct interface
    	IISExt.IISApp2 app = (IISExt.IISApp2)de.NativeObject;
    	int status = app.AppGetStatus2();
    	
    	switch(status)
    	{
    		case 0:
    			Console.WriteLine("It's an app but it's stopped.");
    			break;
    		
    		case 1:
    			Console.WriteLine("It's an app and it's running.");
    			break;
    			
    		case 2:
    			Console.WriteLine("No application found here.");
    			break;
    	}
    	
    }
