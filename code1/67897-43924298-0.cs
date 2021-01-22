    private static bool? areWeConnected = null;
    private static bool checkSocket(string svrAddress, int port)
    {
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(svrAddress), port);
        Socket socket = new Socket(endPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        int timeout = 5000; // int.Parse(ConfigurationManager.AppSettings["socketTimeout"].ToString());
        int ctr = 0;
        IAsyncResult ar = socket.BeginConnect(endPoint, Connect_Callback, socket);
        ar.AsyncWaitHandle.WaitOne( timeout, true );
        // Sometimes it returns here as null before it's done checking the connection
        // No idea why, since .WaitOne() should block that, but it does happen
        while (areWeConnected == null && ctr < timeout)
        {
            Thread.Sleep(100);
            ctr += 100;
        } // Given 100ms between checks, it allows 50 checks 
          // for a 5 second timeout before we give up and return false, below
        if (areWeConnected == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private static void Connect_Callback(IAsyncResult ar)
    {
        areWeConnected = null;
        try
        {
            Socket socket = (Socket)ar.AsyncState;
            areWeConnected = socket.Connected;
            socket.EndConnect(ar);
        }
        catch (Exception ex)
        {
          areWeConnected = false;
          // log exception 
        }
    }
