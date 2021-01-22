    // The call to InvokeMethod below will fail if the Handle property is not retrieved
    string[] propertiesToSelect = new[] { "Handle", "ProcessId" };
    SelectQuery processQuery = new SelectQuery("Win32_Process", "Name = 'taskhost.exe'", propertiesToSelect);
    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(processQuery))
    using (ManagementObjectCollection processes = searcher.Get())
        foreach (ManagementObject process in processes)
        {
            object[] outParameters = new object[2];
            uint result = (uint) process.InvokeMethod("GetOwner", outParameters);
            if (result == 0)
            {
                string user = (string) outParameters[0];
                string domain = (string) outParameters[1];
                uint processId = (uint) process["ProcessId"];
                // Use process data...
            }
            else
            {
                // Handle GetOwner() failure...
            }
        }
