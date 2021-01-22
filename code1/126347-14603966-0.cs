    NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
    foreach (NetworkInterface adapter in nics)
    {
      IPInterfaceProperties ip_properties = adapter.GetIPProperties();
      if (!adapter.GetIPProperties().MulticastAddresses.Any())
        continue; // most of VPN adapters will be skipped
      if (!adapter.SupportsMulticast)
        continue; // multicast is meaningless for this type of connection
      if (OperationalStatus.Up != adapter.OperationalStatus)
        continue; // this adapter is off or not connected
      IPv4InterfaceProperties p = adapter.GetIPProperties().GetIPv4Properties();
      if (null == p)
        continue; // IPv4 is not configured on this adapter
      // now we have adapter index as p.Index, let put it to socket option
      my_sock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, (int)IPAddress.HostToNetworkOrder(p.Index));
    }
