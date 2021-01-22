    IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
    IPEndPoint[] endPoints = ipProperties.GetActiveTcpListeners();
    TcpConnectionInformation[] tcpConnections = 
        ipProperties.GetActiveTcpConnections();
    foreach (TcpConnectionInformation info in tcpConnections)
    {
        Console.WriteLine("Local: {0}:{1}\nRemote: {2}:{3}\nState: {4}\n", 
            info.LocalEndPoint.Address, info.LocalEndPoint.Port,
            info.RemoteEndPoint.Address, info.RemoteEndPoint.Port,
            info.State.ToString());
    }
    Console.ReadLine();
