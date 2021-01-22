    using System.Management;
    public string GetHDDSerial()
    {
        ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
        foreach (ManagementObject wmi_HD in searcher.Get())
        {
            // get the hardware serial no.
            if (wmi_HD["SerialNumber"] != null)
                return wmi_HD["SerialNumber"].ToString();
        }
        return string.Empty;
    }
