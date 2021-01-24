    public static ulong GetTotalPhysicalMemory()
    {
        ManagementScope mScope = new ManagementScope($@"\\{Environment.MachineName}\root\CIMV2");
        SelectQuery mQuery = new SelectQuery("SELECT * FROM Win32_PhysicalMemory");
        mScope.Connect();
        ulong installedMemory = 0;
        using (ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(mScope, mQuery))
        {
            foreach (ManagementObject moMemory in moSearcher.Get())
            {
                installedMemory += (UInt64)moMemory["Capacity"];
            }
        }
        return installedMemory;
    }
