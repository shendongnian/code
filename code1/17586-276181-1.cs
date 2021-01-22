    oConn.Username = "JohnDoe";
    oConn.Password = "JohnsPass";
    
    System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\MachineX", oConn);    
    
    //get Fixed disk stats
    System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select FreeSpace,Size,Name from Win32_LogicalDisk where DriveType=3");
    
    //Execute the query 
    ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs,oQuery);
    
    //Get the results
    ManagementObjectCollection oReturnCollection = oSearcher.Get();   
             
    //loop through found drives and write out info
    foreach( ManagementObject oReturn in oReturnCollection )
    {
        // Disk name
        Console.WriteLine("Name : " + oReturn["Name"].ToString());
        // Free Space in bytes
        Console.WriteLine("FreeSpace: " + oReturn["FreeSpace"].ToString());
        // Size in bytes
        Console.WriteLine("Size: " + oReturn["Size"].ToString());
    } 
