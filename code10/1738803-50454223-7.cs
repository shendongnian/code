    using System.Net.NetworkInformation;
    public class NetWorkInterfacesInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PhysicalAddress MAC { get; set; }
        public List<IPAddress> IPAddresses { get; set; }
        public List<IPAddress> DnsServers { get; set; }
        public List<IPAddress> Gateways { get; set; }
        public bool DHCPEnabled { get; set; }
        public OperationalStatus Status { get; set; }
        public NetworkInterfaceType InterfaceType { get; set; }
        public Int64 Speed { get; set; }
        public Int64 BytesSent { get; set; }
        public Int64 BytesReceived { get; set; }
    }
    List<NetWorkInterfacesInfo> NetInterfacesInfo = new List<NetWorkInterfacesInfo>();
    NetInterfacesInfo = DhcpInterfaces.Select(IF => new NetWorkInterfacesInfo()
    {
        Name = IF.Name,
        Description = IF.Description,
        Status = IF.OperationalStatus,
        Speed = IF.Speed,
        InterfaceType = IF.NetworkInterfaceType,
        MAC = IF.GetPhysicalAddress(),
        DnsServers = IF.GetIPProperties().DnsAddresses.Select(ipa => ipa).ToList(),
        IPAddresses = IF.GetIPProperties().UnicastAddresses.Select(ipa => ipa.Address).ToList(),
        Gateways = IF.GetIPProperties().GatewayAddresses.Select(ipa => ipa.Address).ToList(),
        DHCPEnabled = IF.GetIPProperties().GetIPv4Properties().IsDhcpEnabled,
        BytesSent = IF.GetIPStatistics().BytesSent,
        BytesReceived = IF.GetIPStatistics().BytesReceived
    }).ToList();
