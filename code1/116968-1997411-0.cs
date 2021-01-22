    class AcceptState
    {
        public Socket Socket{ get; set; }
        public string IdString { get; set; }
        public Action<string> Accepted { get; set; }
    }
    public void serverBeginAceept(int serverPort, string id, Action<string> accepted)
    {
        mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, serverPort);
        var state = new AcceptState() {
            Socket = mainSocket,
            IdString = id,
            Accepted = accepted,
        };
        mainSocket.Bind(ipEndPoint);
        mainSocket.Listen(MAX_CONNECTIONS);
        mainSocket.BeginAccept(new AsyncCallback(serverEndAccept), );
    }
    public void serverEndAccept(IAsyncResult iar)
    {
        var state = (AcceptState)iar.AsyncState;
        mainSocket = state.Socket.EndAccept(iar);
        state.Accepted(state.IdString);
    }
