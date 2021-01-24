    public void StartServer()
    {
        var udpServer = new UdpClient(new IPEndPoint(IPAddress.Any, ConnectionInformation.DETECTION_PORT));
        udpServer.BeginReceive(new AsyncCallback(detectionCallback), udpServer);
    }
    private void detectionCallback(IAsyncResult ar)
    {
        var client = (ar.AsyncState as UdpClient);
        if (client.Client == null) return;
        var endPoint = new IPEndPoint(IPAddress.Any, ConnectionInformation.DETECTION_PORT);
        var bytes = client.EndReceive(ar, ref endPoint);
        Debug.WriteLine($"Detection request from: {endPoint}");
    }
