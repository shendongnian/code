    // Namespace Reference
    using System.Management;
    
    /// <summary>
    /// method to retrieve the selected HDD's serial number
    /// </summary>
    /// <param name="strDriveLetter">Drive letter to retrieve serial number for</param>
    /// <returns>the HDD's serial number</returns>
    public string GetHDDSerialNumber(string drive)
    {
        //check to see if the user provided a drive letter
        //if not default it to "C"
        if (drive == "" || drive == null)
        {
            drive = "C";
        }
        //create our ManagementObject, passing it the drive letter to the
        //DevideID using WQL
        ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + drive +":\"");
        //bind our management object
        disk.Get();
        //return the serial number
        return disk["VolumeSerialNumber"].ToString();
    }
