    public static int GetAvailablePort(int startingPort)
    {
        var portArray = new List<int>();
        var properties = IPGlobalProperties.GetIPGlobalProperties();
        // Ignore active connections
        var connections = properties.GetActiveTcpConnections();
        portArray.AddRange(from n in connections
                            where n.LocalEndPoint.Port >= startingPort
                            select n.LocalEndPoint.Port);
        // Ignore active tcp listners
        var endPoints = properties.GetActiveTcpListeners();
        portArray.AddRange(from n in endPoints
                            where n.Port >= startingPort
                            select n.Port);
        // Ignore active UDP listeners
        endPoints = properties.GetActiveUdpListeners();
        portArray.AddRange(from n in endPoints
                            where n.Port >= startingPort
                            select n.Port);
        portArray.Sort();
        for (var i = startingPort; i < UInt16.MaxValue; i++)
            if (!portArray.Contains(i))
                return i;
        return 0;
    }
