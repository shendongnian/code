    using (System.Net.Sockets.TcpClient client = whatever) {
        System.Net.EndPoint ep = client.Client.RemoteEndPoint;
        System.Net.IPEndPoint ip = (System.Net.IPEndPoint)ep;
        DoSomethingWith(ip.Address);
    }
