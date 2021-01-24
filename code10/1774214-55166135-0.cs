    var availableMulticastNics = Utils.GetAvailableMulticastInterfaces();
    var listener = new UdpClient();
    listener.Client.Bind(new IPEndPoint(IPAddress.Any, endpoint.Port));
    foreach (var ni in availableMulticastNics)
    {
        listener.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.AddMembership, new MulticastOption(multicastEndPoint.Address, ni.GetIPProperties().GetIPv4Properties().Index));
    }
    // Ready to read socket
