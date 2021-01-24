    string GetMacAddress()
    {
        string reesult = "";
        foreach (NetworkInterface ninf in NetworkInterface.GetAllNetworkInterfaces())
        {
            if (ninf.NetworkInterfaceType != NetworkInterfaceType.Ethernet) continue;
            if (ninf.OperationalStatus == OperationalStatus.Up)
            {
                reesult += ninf.GetPhysicalAddress().ToString();
                break;
            }
        }
        return reesult;
    }
