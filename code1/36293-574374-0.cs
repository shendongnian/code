    //Include
    using System.Diagnostics;
    using Microsoft.Win32; 
    // Usage
    // HKEY_LOCAL_MACHINE\SOFTWARE\Classes\CLSID\{0006F03A-0000-0000-C000-000000000046} << This is outlook 2003
    String retval = "";
    // Look to see if Outlook 2003 is installed and if it is...
    if ((checkComServerExists("{0006F03A-0000-0000-C000-000000000046}", out retval)))
    {
        // Update boolean flag if we get this far so we don't have to check again
        Console.WriteLine("Office CSLID exists - Version: " + retval);
    }
    // Checks to see if the given CLSID is registerd and exists on the system
    private static Boolean checkComServerExists(String CLSID, out String retval)
    {
        RegistryKey myRegKey = Registry.LocalMachine;
        Object val;
        try
        {
            // get the pathname to the COM server DLL/EXE if the key exists
            myRegKey = myRegKey.OpenSubKey("SOFTWARE\\Classes\\CLSID\\" + CLSID + "\\LocalServer32");
            val = myRegKey.GetValue(null); // the null gets default
        }
        catch
        {
            retval = "CLSID not registered";
            return false;
        }
        FileVersionInfo myFileVersionInfo = null;
        try
        {
            // parse out the version number embedded in the resource
            // in the DLL
            myFileVersionInfo = FileVersionInfo.GetVersionInfo(val.ToString());
        }
        catch
        {
            retval = String.Format("DLL {0} not found", val.ToString());
            return false;
        }
        retval = myFileVersionInfo.FileVersion;
        return true;
    }
