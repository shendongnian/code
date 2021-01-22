    public static string GetMACAddress()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
        IEnumerable<ManagementObject> objects = searcher.Get().Cast<ManagementObject>();
        string mac = (from o in objects orderby o["IPConnectionMetric"] select o["MACAddress"].ToString()).FirstOrDefault();
        return mac;
    }
