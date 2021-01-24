	using System.Management;	
	ManagementObjectSearcher objSearch= new ManagementObjectSearcher("select * from Win32_VideoController");
	foreach (ManagementObject share in objSearch.Get())
	{	
		// Some logic...
		//if want to loop through properties
		foreach (PropertyData PC in share.Properties)
		{
			 //some logic...
		}
	}
