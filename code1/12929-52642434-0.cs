    static NetworkInterface GetNetworkInterface(string macAddress)
    {
        foreach(NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (macAddress == ni.GetPhysicalAddress().ToString())
                return ni;
        }
        return null;
    }
    static ManagementObject GetNetworkInterfaceManagementObject(string macAddress)
    {
        NetworkInterface ni = GetNetworkInterface(macAddress);
        if (ni == null)
            return null;
        ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
        ManagementObjectCollection moc = managementClass.GetInstances();
        foreach(ManagementObject mo in moc)
        {
            if (mo["settingID"].ToString() == ni.Id)
                return mo;
        }
        return null;
    }
    static bool SetupNIC(string macAddress, string ip, string subnet, string gateway, string dns)
    {
        try
        {
            ManagementObject mo = GetNetworkInterfaceManagementObject(macAddress);
            //Set IP
            ManagementBaseObject mboIP = mo.GetMethodParameters("EnableStatic");
            mboIP["IPAddress"] = new string[] { ip };
            mboIP["SubnetMask"] = new string[] { subnet };
            mo.InvokeMethod("EnableStatic", mboIP, null);
            //Set Gateway
            ManagementBaseObject mboGateway = mo.GetMethodParameters("SetGateways");
            mboGateway["DefaultIPGateway"] = new string[] { gateway };
            mboGateway["GatewayCostMetric"] = new int[] { 1 };
            mo.InvokeMethod("SetGateways", mboGateway, null);
            //Set DNS
            ManagementBaseObject mboDNS = mo.GetMethodParameters("SetDNSServerSearchOrder");
            mboDNS["DNSServerSearchOrder"] = new string[] { dns };
            mo.InvokeMethod("SetDNSServerSearchOrder", mboDNS, null);
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
