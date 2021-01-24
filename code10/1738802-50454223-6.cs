    List<NetworkInterface> DhcpInterfaces = Interfaces
        .Where(IF => (IF.Supports(NetworkInterfaceComponent.IPv4)) &&
              (IF.GetIPProperties().GetIPv4Properties().IsDhcpEnabled))
        .ToList();
                                                                     
    if (DhcpInterfaces != null)
    {
        IEnumerable<UnicastIPAddressInformation> IpAddresses = 
            DhcpInterfaces.Select(IF => IF.GetIPProperties().UnicastAddresses.Last());
    }
