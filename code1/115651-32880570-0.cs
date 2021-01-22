    Socket server = null;
    
    //Authenticate using control password
    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9151);
    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    server.Connect(endPoint);
    server.Send(Encoding.ASCII.GetBytes("AUTHENTICATE \"your_password\"" + Environment.NewLine));
    byte[] data = new byte[1024];
    int receivedDataLength = server.Receive(data);
    string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
    
    //Request a new Identity
    server.Send(Encoding.ASCII.GetBytes("SIGNAL NEWNYM" + Environment.NewLine));
    data = new byte[1024];
    receivedDataLength = server.Receive(data);
    stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
    if (!stringData.Contains("250"))
    {
        Console.WriteLine("Unable to signal new user to server.");
        server.Shutdown(SocketShutdown.Both);
        server.Close();
    }
    else
    {
        Console.WriteLine("SIGNAL NEWNYM sent successfully");
    }
