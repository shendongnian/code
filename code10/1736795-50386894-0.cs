    // order interfaces by speed and filter out down and loopback
    // take first of the remaining
    var firstUpInterface = NetworkInterface.GetAllNetworkInterfaces()
        .OrderByDescending(c => c.Speed)
        .FirstOrDefault(c => c.NetworkInterfaceType != NetworkInterfaceType.Loopback && c.OperationalStatus == OperationalStatus.Up);
    if (firstUpInterface != null) {
        var props = firstUpInterface.GetIPProperties();
        // get first IPV4 address assigned to this interface
        var firstIpV4Address = props.UnicastAddresses
            .Where(c => c.Address.AddressFamily == AddressFamily.InterNetwork)
            .Select(c => c.Address)
            .FirstOrDefault();
    }
