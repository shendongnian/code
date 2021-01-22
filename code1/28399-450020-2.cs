    // add a reference to the System.Management assembly and
    // import the System.Management namespace at the top in your "using" statement.
    // Then in a method, or on a button click:
 
    ManagementObjectSearcher theSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
    foreach (ManagementObject currentObject in theSearcher.Get())
    {
       ManagementObject theSerialNumberObjectQuery = new ManagementObject("Win32_PhysicalMedia.Tag='" + currentObject["DeviceID"] + "'");
       MessageBox.Show(theSerialNumberObjectQuery["SerialNumber"].ToString());
    }
