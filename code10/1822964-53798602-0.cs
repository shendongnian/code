    public void Send()
    {
        Connection = new NetworkConnection();
        var info = LobbyRenderer.GetSelectedHostInfo();
        Connection.Initialize(info.ipv4, 1, 1, new HostTopology(new ConnectionConfig(), 1));
    
        byte connectionError;
        ConnectionConfig config = new ConnectionConfig();
        int myReliableChannelId  = config.AddChannel(QosType.Reliable);
        int myUnreliableChannelId = config.AddChannel(QosType.Unreliable);
        websocketId = NetworkTransport.AddWebsocketHost(new HostTopology(config, 1), 47774);
        connectionId = NetworkTransport.Connect(websocketId, info.ipv4, 47774, 0, out connectionError);
    
        byte sendError;
        byte[] bytes = new byte[2] { 1,1 };
        NetworkTransport.Send(websocketId, connectionId, myReliableChannelId, bytes, 2, out sendError);
    }
