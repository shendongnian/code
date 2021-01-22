    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
    
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
    
            }
    
        }
    
        return "unknown";
    }
    
    public static string GetLocalIpAllocationMode()
    {
        string MethodResult = "";
        try
        {
            ManagementObjectSearcher searcherNetwork = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_NetworkAdapterConfiguration");
    
            Dictionary<string, string> Properties = new Dictionary<string, string>();
    
            foreach (ManagementObject queryObj in searcherNetwork.Get())
            {
                foreach (var prop in queryObj.Properties)
                {
                    if (prop.Name != null && prop.Value != null && !Properties.ContainsKey(prop.Name))
                    {
                        Properties.Add(prop.Name, prop.Value.ToString());
    
                    }
    
                }
    
            }
    
            MethodResult = Properties["DHCPEnabled"].ToLower() == "true" ? "DHCP" : "Static";
    
        }
        catch (Exception ex)
        {
            ex.HandleException();
    
        }
    
        return MethodResult;
    
    }
