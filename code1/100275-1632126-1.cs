    string serviceName = "aspnet_state";
    
    SelectQuery query = new System.Management.SelectQuery(string.Format(
        "select name, startname from Win32_Service where name = '{0}'", serviceName));
    using (ManagementObjectSearcher searcher =
        new System.Management.ManagementObjectSearcher(query))
    {
        foreach (ManagementObject service in searcher.Get())
        {
            Console.WriteLine(string.Format(
                "Name: {0} - Logon : {1} ", service["Name"], service["startname"]));
        }
    }
            
