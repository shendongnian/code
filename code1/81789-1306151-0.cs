    SelectQuery q = new SelectQuery("SELECT Name, DeviceID, Description FROM Win32_DesktopMonitor");
    using(ManagementObjectSearcher mos = new ManagementObjectSearcher(q))
    {
        foreach(ManagementObject mo in mos.Get())
        {
            Console.WriteLine("{0}, {1}, {2}",
                mo.Properties["Name"].Value.ToString(),
                mo.Properties["DeviceID"].Value.ToString(),
                mo.Properties["Description"].Value.ToString());
        }
    }
