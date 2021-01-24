    using System.Net.NetworkInformation;
    NetworkInterface[] Interfaces = NetworkInterface.GetAllNetworkInterfaces();
    IPInterfaceProperties IPProperties = Interfaces[0].GetIPProperties();
    IPv4InterfaceProperties IpV4Properties = IPProperties.GetIPv4Properties();
    bool DhcpEnabed = IpV4Properties.IsDhcpEnabled;
