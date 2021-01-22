    string getString = "GET /path/mypage.htm HTTP/1.1\r\nHost: www.mysite.mobi\r\nConnection: Close\r\n\r\n";
    Encoding ASCII = Encoding.ASCII;
    Byte[] byteGetString = ASCII.GetBytes(getString);
    Byte[] receiveByte = new Byte[256];
    Socket socket = null;
    String strPage = null;
    try
    {
        IPEndPoint ip = new IPEndPoint(IPAddress.Parse("10.23.1.93"), 80);
        socket = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        socket.Connect(ip);
    }
    catch (SocketException ex)
    {
        Console.WriteLine("Source:" + ex.Source);
        Console.WriteLine("Message:" + ex.Message);
    }
    socket.Send(byteGetString, byteGetString.Length, 0);
    Int32 bytes = socket.Receive(receiveByte, receiveByte.Length, 0);
    strPage = strPage + ASCII.GetString(receiveByte, 0, bytes);
    
    while (bytes > 0)
    {
        bytes = socket.Receive(receiveByte, receiveByte.Length, 0);
        strPage = strPage + ASCII.GetString(receiveByte, 0, bytes);
    }
    socket.Close();
