    public void StartMonitoring()
    {
        _isMonitoring = true;
        while (_isMonitoring)
            Server.BeginAcceptTcpClient(HandleNewClient, null);
    }
