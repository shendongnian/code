    public static void remoteProcessKill(string computerName, string fullUserName, string pword, string processName)
    {
        var connectoptions = new ConnectionOptions();
        connectoptions.Username = fullUserName;  // @"YourDomainName\UserName";
        connectoptions.Password = pword;
        ManagementScope scope = new ManagementScope(@"\\" + computerName + @"\root\cimv2", connectoptions);
        // WMI query
        var query = new SelectQuery("select * from Win32_process where name = '" + processName + "'");
        using (var searcher = new ManagementObjectSearcher(scope, query))
        {
            foreach (ManagementObject process in searcher.Get()) 
            {
                process.InvokeMethod("Terminate", null);
                process.Dispose();
            }
        }
    }
