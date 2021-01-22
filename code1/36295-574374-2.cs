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
