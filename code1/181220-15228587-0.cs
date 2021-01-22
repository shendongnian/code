    using System.Management;
    string UniqueMachineId()
    {
        StringBuilder builder = new StringBuilder();
        String query = "SELECT * FROM Win32_BIOS";
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
        //  This should only find one
        foreach (ManagementObject item in searcher.Get())
        {
            Object obj = item["Manufacturer"];
            builder.Append(Convert.ToString(obj));
            builder.Append(':');
            obj = item["SerialNumber"];
            builder.Append(Convert.ToString(obj));
        }
    return builder.ToString();
    }
