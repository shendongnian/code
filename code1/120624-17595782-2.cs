    using System.IO; //For DirectoryNotFound exception.
    using System.Management;
    /// <summary>
    /// Given a local mapped drive letter, determine if it is a network drive. If so, return the server share.
    /// </summary>
    /// <param name="mappedDrive"></param>
    /// <returns>The server path that the drive maps to ~ "////XXXXXX//ZZZZ"</returns>
    private string CheckUNCPath(string mappedDrive)
    {
        //Query to return all the local computer's drives.
        //See http://msdn.microsoft.com/en-us/library/ms186146.aspx, or search "WMI Queries"
        SelectQuery selectWMIQuery = new SelectQuery("Win32_LogicalDisk");
        ManagementObjectSearcher driveSearcher = new ManagementObjectSearcher(selectWMIQuery);
    
        //Soem variables to be used inside and out of the foreach.
        ManagementPath path = null;
        ManagementObject networkDrive = null;
        bool found = false;
        string serverName = null;
    
        //Check each disk, determine if it is a network drive, and then return the real server path.
        foreach (ManagementObject disk in driveSearcher.Get())
        {
            path = disk.Path;
    
            if (path.ToString().Contains(mappedDrive))
            {
                networkDrive = new ManagementObject(path);
    
                if (Convert.ToUInt32(networkDrive["DriveType"]) == 4)
                {
                    serverName = Convert.ToString(networkDrive["ProviderName"]);
                    found = true;
                    break;
                }
                else
                {
                    throw new DirectoryNotFoundException("The drive " + mappedDrive + " was found, but is not a network drive. Were your network drives mapped correctly?");
                }
            }
        }
    
        if (!found)
        {
            throw new DirectoryNotFoundException("The drive " + mappedDrive + " was not found. Were your network drives mapped correctly?");
        }
        else
        {
            return serverName;
        }
    }
