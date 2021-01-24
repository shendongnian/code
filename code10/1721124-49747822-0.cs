    private static readonly List<Tuple<IPAddress,int>> _passed = new List<Tuple<IPAddress, int>>();
    private static readonly List<Tuple<IPAddress, int, int>> _failed = new List<Tuple<IPAddress, int, int>>();
    private static readonly object _sync = new object();
     ...
    public static async Task TestSocket(IPAddress ip)
    {
       try
       {
          Console.WriteLine("testing : " + ip);
          // create a socket
          using (var tcpClient = new TcpClient())
          {
             // connect in an async fashion
             await tcpClient.ConnectAsync(ip, 80);
             lock (_sync)
                _passed.Add(new Tuple<IPAddress, int>(ip, 80));
          }
       }
       catch (SocketException ex)
       {
          // if we failed work out why
          lock (_sync)
             _failed.Add(new Tuple<IPAddress, int,  int>(ip, 80, ex.ErrorCode));
       }
    }
