    public bool SetIP(string networkInterfaceName, string ipAddress, string subnetMask, string gateway = null)
    {
        var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nw => nw.Name == networkInterfaceName);
        var ipProperties = networkInterface.GetIPProperties();
        var ipInfo = ipProperties.UnicastAddresses.FirstOrDefault(ip => ip.Address.AddressFamily == AddressFamily.InterNetwork);
        var currentIPaddress = ipInfo.Address.ToString();
        var currentSubnetMask = ipInfo.IPv4Mask.ToString();
        var isDHCPenabled = ipProperties.GetIPv4Properties().IsDhcpEnabled;
        if (!isDHCPenabled && currentIPaddress == ipAddress && currentSubnetMask == subnetMask)
            return true;    // no change necessary
        var process = new Process
        {
            StartInfo = new ProcessStartInfo("netsh", $"interface ip set address \"{networkInterfaceName}\" static {ipAddress} {subnetMask}" + (string.IsNullOrWhiteSpace(gateway) ? "" : $"{gateway} 1")) { Verb = "runas" }
        };
        process.Start();
        var successful = process.ExitCode == 0;
        process.Dispose();
        return successful;
    }
    public bool SetDHCP(string networkInterfaceName)
    {
        var networkInterface = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(nw => nw.Name == networkInterfaceName);
        var ipProperties = networkInterface.GetIPProperties();
        var isDHCPenabled = ipProperties.GetIPv4Properties().IsDhcpEnabled;
        if (isDHCPenabled)
            return true;    // no change necessary
        var process = new Process
        {
            StartInfo = new ProcessStartInfo("netsh", $"interface ip set address \"{networkInterfaceName}\" dhcp") { Verb = "runas" }
        };
        process.Start();
        var successful = process.ExitCode == 0;
        process.Dispose();
        return successful;
    }
