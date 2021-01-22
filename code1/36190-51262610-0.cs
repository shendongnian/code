    private bool isPortAvalaible(int myPort)
    {
        var avalaiblePorts = new List<int>();
        var properties = IPGlobalProperties.GetIPGlobalProperties();
    
        // Active connections
        var connections = properties.GetActiveTcpConnections();
        avalaiblePorts.AddRange(connections);
    
        // Active tcp listners
        var endPointsTcp = properties.GetActiveTcpListeners();
        avalaiblePorts.AddRange(endPointsTcp);
    
        // Active udp listeners
        var endPointsUdp = properties.GetActiveUdpListeners();
        avalaiblePorts.AddRange(endPointsUdp);
    
        foreach (int p in avalaiblePorts){
            if (p == myPort) return false;
        }
    	return true;
    }
