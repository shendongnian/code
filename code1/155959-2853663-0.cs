    public static void Main()
    {
        TcpListener listener = new TcpListener(new IPEndPoint(IPAddress.Loopback, 8080));
        listener.Start();
        listener.BeginAcceptTcpClient(OnConnect, listener);
        Console.WriteLine("Press any key to quit...");
        Console.ReadKey();
    }
    static void OnConnect(IAsyncResult ar)
    {
        TcpListener listener = (TcpListener)ar.AsyncState;
        new TcpReader(listener.EndAcceptTcpClient(ar));
        listener.BeginAcceptTcpClient(OnConnect, listener);
    }
    class TcpReader
    {
        string respose = "HTTP 1.1 200\r\nContent-Length:12\r\n\r\nHello World!";
        TcpClient client;
        NetworkStream socket;
        byte[] buffer;
        public TcpReader(TcpClient client)
        {
            this.client = client;
            socket = client.GetStream();
            buffer = new byte[1024];
            socket.BeginRead(buffer, 0, 1024, OnRead, socket);
        }
        void OnRead(IAsyncResult ar)
        {
            int nBytes = socket.EndRead(ar);
            if (nBytes > 0)
            {
                //you have data... do something with it, http example
                socket.BeginWrite(
                    Encoding.ASCII.GetBytes(respose), 0, respose.Length, null, null);
                socket.BeginRead(buffer, 0, 1024, OnRead, socket);
            }
            else
                socket.Close();
        }
    }
