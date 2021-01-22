    string _osVersion = "";
    string _osServicePack = "";
    string _osArchitecture = "";
    ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
    ManagementObjectCollection collection = searcher.Get();
    foreach (ManagementObject mbo in collection)
    {
        _osVersion = mbo.GetPropertyValue("Caption").ToString();
        _osServicePack = string.Format("{0}.{1}", mbo.GetPropertyValue("ServicePackMajorVersion").ToString(), mbo.GetPropertyValue("ServicePackMinorVersion").ToString());
        try
        {
            _osArchitecture = mbo.GetPropertyValue("OSArchitecture").ToString();
        }
        catch
        {
            // OSArchitecture only supported on Windows 7/Windows Server 2008
        }
    }
    Console.WriteLine("osVersion     : " + _osVersion);
    Console.WriteLine("osServicePack : " + _osServicePack);
    Console.WriteLine("osArchitecture: " + _osArchitecture);
    /////////////////////////////////////////
    // Test on Windows 7 64-bit
    //
    // osVersion     : Microsoft Windows 7 Professional
    // osservicePack : 1.0
    // osArchitecture: 64-bit
    /////////////////////////////////////////
    // Test on Windows Server 2008 64-bit
    //    --The extra r's come from the registered trademark
    //
    // osVersion     : Microsoftr Windows Serverr 2008 Standard
    // osServicePack : 1.0
    // osArchitecture: 64-bit
    /////////////////////////////////////////
    // Test on Windows Server 2003 32-bit
    //    --OSArchitecture property not supported on W2K3
    //
    // osVersion     : Microsoft(R) Windows(R) Server 2003, Standard Edition
    // osServicePack : 2.0
    // osArchitecture:
