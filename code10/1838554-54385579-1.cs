    string wmiQuery = string.Format("select * from Win32_Process where Name='{0}'", "explorer.exe");
    var searcher = new ManagementObjectSearcher(wmiQuery);
    var processes = searcher.Get();
    foreach (ManagementObject retObject in processes)
    {
        foreach(var prop in retObject.Properties)
        {
            if (prop.Name == "CommandLine" && prop.Value.ToString().Contains("--CMD="))
            {
                retObject.InvokeMethod("Terminate", null);
            }
        }
    }
