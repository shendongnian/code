    public static PhysicalAddress GetMacAddress()
    {
        var myInterfaceAddress = NetworkInterface.GetAllNetworkInterfaces()
            .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
            .OrderByDescending(n => n.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
            .Select(n => n.GetPhysicalAddress())
            .FirstOrDefault();
        return myInterfaceAddress;
    }
