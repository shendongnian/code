    private int GetFreePortInRange(int PortStartIndex, int PortEndIndex)
    {
        DevUtils.LogDebugMessage(string.Format("GetFreePortInRange, PortStartIndex: {0} PortEndIndex: {1}", PortStartIndex, PortEndIndex));
        try
        {
            IPGlobalProperties ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] tcpEndPoints = ipGlobalProperties.GetActiveTcpListeners();
            List<int> usedServerTCpPorts = tcpEndPoints.Select(p => p.Port).ToList<int>();
            IPEndPoint[] udpEndPoints = ipGlobalProperties.GetActiveUdpListeners();
            List<int> usedServerUdpPorts = udpEndPoints.Select(p => p.Port).ToList<int>();
            TcpConnectionInformation[] tcpConnInfoArray = ipGlobalProperties.GetActiveTcpConnections();
            List<int> usedPorts = tcpConnInfoArray.Where(p=> p.State != TcpState.Closed).Select(p => p.LocalEndPoint.Port).ToList<int>();
            usedPorts.AddRange(usedServerTCpPorts.ToArray());
            usedPorts.AddRange(usedServerUdpPorts.ToArray());
            int unusedPort = 0;
            for (int port = PortStartIndex; port < PortEndIndex; port++)
            {
                if (!usedPorts.Contains(port))
                {
                    unusedPort = port;
                    break;
                }
            }
            DevUtils.LogDebugMessage(string.Format("Local unused Port:{0}", unusedPort.ToString()));
            if (unusedPort == 0)
            {
                DevUtils.LogErrorMessage("Out of ports");
                throw new ApplicationException("GetFreePortInRange, Out of ports");
            }
            return unusedPort;
        }
        catch (Exception ex)
        {
            string errorMessage = ex.Message;
            DevUtils.LogErrorMessage(errorMessage);
            throw;
        }
    }
    private int GetLocalFreePort()
    {
        int hemoStartLocalPort = int.Parse(DBConfig.GetField("Site.Config.hemoStartLocalPort"));
        int hemoEndLocalPort = int.Parse(DBConfig.GetField("Site.Config.hemoEndLocalPort"));
        int localPort = GetFreePortInRange(hemoStartLocalPort, hemoEndLocalPort);
        DevUtils.LogDebugMessage(string.Format("Local Free Port:{0}", localPort.ToString()));
        return localPort;
    }
    public void Connect(string host, int port)
    {
        try
        {
            // Create socket
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            var localPort = GetLocalFreePort();
            // Create an endpoint for the specified IP on any port
            IPEndPoint bindEndPoint = new IPEndPoint(IPAddress.Any, localPort);
            // Bind the socket to the endpoint
            socket.Bind(bindEndPoint);
            // Connect to host
            socket.Connect(IPAddress.Parse(host), port);
            socket.Dispose();
        }
        catch (SocketException ex)
        {
            // Get the error message
            string errorMessage = ex.Message;
            DevUtils.LogErrorMessage(errorMessage);
        }
    }
    public void Connect2(string host, int port)
    {
        try
        {
            // Create socket
            var localPort = GetLocalFreePort();
            // Create an endpoint for the specified IP on any port
            IPEndPoint bindEndPoint = new IPEndPoint(IPAddress.Any, localPort);
            var client = new TcpClient(bindEndPoint);
            //client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true); //will release port when done
            // Connect to the host
            client.Connect(IPAddress.Parse(host), port);
            client.Close();
        }
        catch (SocketException ex)
        {
            // Get the error message
            string errorMessage = ex.Message;
            DevUtils.LogErrorMessage(errorMessage);
        }
    }
