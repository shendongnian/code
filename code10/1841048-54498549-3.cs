    public static ulong WMIGetTotalPhysicalMemory()
    {
        ManagementScope mScope = new ManagementScope($@"\\{Environment.MachineName}\root\CIMV2");
        SelectQuery mQuery = new SelectQuery("SELECT * FROM Win32_PhysicalMemory");
        mScope.Connect();
        ulong installedMemory = 0;
        using (ManagementObjectSearcher moSearcher = new ManagementObjectSearcher(mScope, mQuery))
        {
            foreach (ManagementObject moCapacity in moSearcher.Get()) {
                installedMemory += (UInt64)moCapacity["Capacity"];
            }
        }
        return installedMemory;
    }
