     System.Management.ConnectionOptions myConnectionOptions = new System.Management.ConnectionOptions();
    	    myConnectionOptions.Impersonation  = System.Management.ImpersonationLevel.Impersonate;
    	
	    System.Management.ManagementScope  objwmiservice;
	    System.Management.ManagementObjectSearcher myObjectSearcher;
	    System.Management.ManagementObjectCollection myCollection;
	
	    try
	    {
	        objwmiservice = new System.Management.ManagementScope( ("\\\\" + (HostOrIP + "\\root\\cimv2")), myConnectionOptions);
	        objwmiservice.Connect();
	        myObjectSearcher = new System.Management.ManagementObjectSearcher(objwmiservice.Path.ToString(), "Select UserName from Win32_ComputerSystem");
	        myObjectSearcher.Options.Timeout = new TimeSpan(0, 0, 0, 0, 7000);
	        myCollection = myObjectSearcher.Get();
    	
	        foreach (System.Management.ManagementObject myObject in myCollection)
	        {
	            if (!(myObject.GetPropertyValue("User name") == null))
	            {
	                string Userx = myObject.GetPropertyValue("Usernam e").ToString();
	                int posx = Userx.LastIndexOf("\\");
	                if ((posx > 0))
	                {
	                    Userx = Userx.Substring((posx + 1));
	                    return Userx.ToUpper();
	                }
	            }
	         }
	         return "<Nobody>";
	     }
	     catch (Exception)
	     {
	            return "<Nobody>";
	     }
    }
