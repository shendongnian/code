    using System;
    using System.Management;
    class Test
    {
	    static void Main()
	    {
		    var moCollection = new ManagementClass("Win32_LogicalDisk").GetInstances();
		    foreach (var mo in moCollection)
		    {
			    if (mo["DeviceID"] != null && mo["DriveType"] != null && mo["Size"] != null && mo["FreeSpace"] != null)
			    {
				    // DriveType 3 = "Local Disk"
			    	if (Convert.ToInt32(mo["DriveType"]) == 3)
				    {
				    	Console.WriteLine("Drive {0}", mo["DeviceID"]);
				    	Console.WriteLine("Size {0} bytes", mo["Size"]);
				    	Console.WriteLine("Free {0} bytes", mo["FreeSpace"]);
				    }
			    }
		    }
	    }
    }
