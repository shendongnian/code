    // There could be multiple adapters, get the default one
    uint index = 0;
    GetBestInterface(0, out index);
    var ifaceIndex = (int)index;
   
    var client = new UdpClient();
    client.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastInterface, (int)IPAddress.HostToNetworkOrder(ifaceIndex));
    var localEndpoint = new IPEndPoint(IPAddress.Any, <port>);
    client.Client.Bind(localEndpoint);
    var multicastAddress = IPAddress.Parse("<group IP>");
    var multOpt = new MulticastOption(multicastAddress, ifaceIndex);
    client.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, multOpt);
    var broadcastEndpoint = new IPEndPoint(IPAddress.Parse("<group IP>"), <port>);
    byte[] buffer = ...
    await client.SendAsync(buffer, buffer.Length, broadcastEp).ConfigureAwait(false);
