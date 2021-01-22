    /// <summary>
    /// THIS FUNCTION WILL CHECK IF CLIENT IS STILL CONNECTED WITH SERVER.
    /// </summary>
    /// <returns>FALSE IF NOT CONNECTED ELSE TRUE</returns>
    public bool isClientConnected()
    {
        IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] tcpConnections = ipProperties.GetActiveTcpConnections();
        
        foreach (TcpConnectionInformation c in tcpConnections)
        {
            TcpState stateOfConnection = c.State;
            if (c.LocalEndPoint.Equals(ClientSocket.Client.LocalEndPoint) && c.RemoteEndPoint.Equals(ClientSocket.Client.RemoteEndPoint))
            {
                if (stateOfConnection == TcpState.Established)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
        return false;
              
    
    }
