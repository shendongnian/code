    internal void Initialize(int port,string IP) {
        IPEndPoint _Point = new IPEndPoint(IPAddress.Parse(IP), port);
        Socket _Accpt = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        _Accpt.Bind(_Point);
        _Accpt.Listen(2);
        _Accpt.BeginAccept(null, 0, new AsyncCallback(Accept), _Accpt);
    }
    private void Accept(IAsyncResult async) {
        Socket _Accpt = (Socket)async.AsyncState;
        Socket _Handler;
        try {
            _Handler = _Accpt.EndAccept(async);
        } finally {
            _Accpt.BeginAccept(null, 0, new AsyncCallback(Accept), _Accpt);
        }
        StateObject _State = new StateObject();
        _State.workSocket = _Handler;
        _Handler.BeginReceive(_State.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), _State);
    }
