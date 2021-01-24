    string sPath = null;
    RegistryKey hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
    RegistryKey appKey = hklm.OpenSubKey(@"SOFTWARE\Tomcat\Common");
    if(appKey != null)
    {
        object oPath = appKey.GetValue("OCR_path", null);
        if(oPath != null && oPath is string)
        {
            sPath = oPath.ToString();
        }
    }
