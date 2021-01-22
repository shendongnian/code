    TcpClient client = new TcpClient(host, port);
    
    IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
    TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections().Where(x => x.LocalEndPoint.Equals(client.Client.LocalEndPoint) && x.RemoteEndPoint.Equals(client.Client.RemoteEndPoint)).ToArray();
    
    if (tcpConnections != null && tcpConnections.Length > 0)
    {
        TcpState stateOfConnection = tcpConnections.First().State;
        if (stateOfConnection == TcpState.Established)
        {
            // Connection is OK
        }
        else 
        {
            // No active tcp Connection to hostName:port
        }
    
    }
    client.Close();
