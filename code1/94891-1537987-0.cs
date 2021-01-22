    void GetComputerSystem()
    {
            // http://msdn.microsoft.com/en-us/library/aa394102(VS.85).aspx
            ManagementObjectCollection oReturnCollection;
    		try
    		{
    			ObjectQuery query = new ObjectQuery("Select UserName,Name,Manufacturer,Model from Win32_ComputerSystem");
    			ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(gManager, query);
    			oReturnCollection = oSearcher.Get();
    			oSearcher.Dispose();
    		}
    		catch
    		{
    			gHasError = true;
    			return;
    		}
    
            //loop through found drives and write out info
    		foreach (ManagementObject oReturn in oReturnCollection)
    		{
            // Disk name  
    			object oLoggedInUser = oReturn["UserName"];
    			if (oLoggedInUser == null)
    				gOSInfo.UserName = "None";
    			else
    				gOSInfo.UserName = (string)oLoggedInUser;
    
    			string Manufacturer = (string)oReturn["Manufacturer"];
    			string Model = (string)oReturn["Model"];
    		}
    	}
    }
