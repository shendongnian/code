    public static string GetMACAddress()
    {
        string mac = null;
        if ((Application.Current.IsRunningOutOfBrowser) && (Application.Current.HasElevatedPermissions) && (AutomationFactory.IsAvailable))
        {
            dynamic sWbemLocator = AutomationFactory.CreateObject("WbemScripting.SWBemLocator");
            dynamic sWbemServices = sWbemLocator.ConnectServer(".");
            sWbemServices.Security_.ImpersonationLevel = 3; //impersonate
            string query = "SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true";
            dynamic results = sWbemServices.ExecQuery(query);
            
            int mtu = int.MaxValue;
            foreach (dynamic result in results)
            {
                if (result.IPConnectionMetric < mtu)
                {
                    mtu = result.IPConnectionMetric;
                    mac = result.MACAddress;
                }
            }
        }
        return mac;
    }
