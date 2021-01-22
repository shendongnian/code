    static void Main(string[] args)
    {
        try
        {
            using (Socket s = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp))
            {
                Console.WriteLine("Connecting");
                s.Connect("www.google.com", 80);
                Console.WriteLine("Connected OK");
                s.Send(new byte[] { 1 });
                Console.WriteLine("Sent Byte OK");
                Console.WriteLine("Local EndPoint Netstat       = " + 
                    GetLocalEndPoint(s));
                Console.WriteLine("Local EndPoint LocalEndPoint = " + 
                    ((IPEndPoint)s.LocalEndPoint).ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception - " + e.Message);
        }
    }
    static string GetLocalEndPoint(Socket s)
    {
        Console.WriteLine(DateTime.Now.TimeOfDay.ToString() + 
            " Find IP LocalEndPoint");
        IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
        TcpConnectionInformation[] connections = 
            properties.GetActiveTcpConnections();
        IPEndPoint remoteEP = (IPEndPoint)s.RemoteEndPoint;
        foreach (TcpConnectionInformation netstat in connections)
        {
            if (remoteEP.ToString() == netstat.RemoteEndPoint.ToString())
            {
                Console.WriteLine(DateTime.Now.TimeOfDay.ToString() + 
                    " Find IP LocalEndPoint OK");
                //Use the "Netstat" IP but the socket.LocalEndPoint port
                return new IPEndPoint(netstat.LocalEndPoint.Address, 
                    ((IPEndPoint)s.LocalEndPoint).Port).ToString();
            }
        }
        return string.Empty;
    }
    Connecting
    Connected OK
    Sent Byte OK
    09:57:38.5312500 Find IP LocalEndPoint
    09:57:38.5312500 Find IP LocalEndPoint OK
    Local EndPoint Netstat       = 10.0.0.6:1711
    Local EndPoint LocalEndPoint = 0.0.0.0:1711
