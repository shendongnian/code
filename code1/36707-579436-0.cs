    TcpClient client = new TcpClient();
    Socket s = client.Client;
    if (!s.Connected)
    {
       s.SetSocketOption(SocketOptionLevel.IP, 
                         SocketOptionName.TypeOfService, 2);
    }
    
