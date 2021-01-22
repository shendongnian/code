    private void ListenForClients()
    {
        while(true)
        {
            TcpClient client = listener.AcceptTcpClient();
            new Thread(new ParameterizedThreadStart(HandleClientCom)).Start(client);
        }
    }
