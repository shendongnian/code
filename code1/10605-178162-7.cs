    using System.ServiceProcess;
    //
    ServiceController sc;
    try
    {
        sc = new ServiceController( SERVICE_NAME );
    }
    catch( ArgumentException )
    {
        return "Invalid service name."; // Note that just because a name is valid does not mean the service exists.
    }
    using( sc )
    {
        ServiceControllerStatus status;
        try
        {
            sc.Refresh(); // calling sc.Refresh() is unnecessary on the first use of `Status` but if you keep the ServiceController in-memory then be sure to call this if you're using it periodically.
            status = sc.Status;
        }
        catch( Win32Exception ex )
        {
            // A Win32Exception will be raised if the service-name does not exist or the running process has insufficient permissions to query service status.
            // See Win32 QueryServiceStatus()'s documentation.
            return "Error: " + ex.Message;
        }
        switch( status )
        {
    	    case ServiceControllerStatus.Running:
    	        return "Running";
    	    case ServiceControllerStatus.Stopped:
    	        return "Stopped";
    	    case ServiceControllerStatus.Paused:
    	        return "Paused";
            case ServiceControllerStatus.StopPending:
                return "Stopping";
            case ServiceControllerStatus.StartPending:
                return "Starting";
    	    default:
    	        return "Status Changing";
        }
    }
    
