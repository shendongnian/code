    TcpListener listener = new TcpListener(IPAddress.Any, port);
    TcpClient client = listener.AcceptTcpClient();
    
    IPEndPoint endPoint = (IPEndPoint) client.Client.RemoteEndPoint;
    // .. or LocalEndPoint - depending on which end you want to identify
    IPAddress ipAddress = endPoint.Address;
    // get the hostname
    IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
    string hostName = hostEntry.HostName;
    // get the port
    int port = endPoint.Port;
