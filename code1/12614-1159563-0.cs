    /// <summary>
    /// Returns the Account name for the specified SID 
    // using WMI against the specified remote machine
    /// </summary>
    private string RemoteSID2AccountName(String MachineName, String SIDString)
    {
        ManagementScope oScope = new ManagementScope(@"\\" + MachineName +     
           @"\root\cimv2");
        ManagementPath oPath = new ManagementPath("Win32_SID.SID='" + SIDString + "'");
        ManagementObject oObject = new ManagementObject(oScope, oPath, null);
        return oObject["AccountName"].ToString();
    }
