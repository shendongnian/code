        private string _hostName;
        private const int _LISTENINGPORT = 23;
        private Socket _incomingSocket;
        byte[] _recievedData;
        //todo: do we need 1024 byte? the asynch methods read the bytes as they come
        //so when 1 byte typed == 1 byte read. Unless its new line then it is two.
        private const int _DATASIZE = 1024;
        public ConnectionServer()
        {
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");
            _hostName = Dns.GetHostName();
            _recievedData = new byte[_DATASIZE];
            _incomingSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(localAddr, _LISTENINGPORT);
            _incomingSocket.Bind(endPoint);
            _incomingSocket.Listen(10);
        }
        ~ConnectionServer()
        {
        }
        public void StartListening()
        {
            _incomingSocket.BeginAccept(new AsyncCallback(OnAccept), _incomingSocket);
        }
        private void OnAccept(IAsyncResult result)
        {
            UserConnection connectionInfo = new UserConnection();
            Socket acceptedSocket = (Socket)result.AsyncState;
            connectionInfo.userSocket = acceptedSocket.EndAccept(result);
            connectionInfo.messageBuffer = new byte[_DATASIZE];
            //Begin acynch communication with target socket
            connectionInfo.userSocket.BeginReceive(connectionInfo.messageBuffer, 0, _DATASIZE, SocketFlags.None,
                new AsyncCallback(OnReceiveMessage), connectionInfo);
            //reset the listnening socket to start accepting 
            _incomingSocket.BeginAccept(new AsyncCallback(OnAccept), result.AsyncState);
        }
       private void OnReceiveMessage(IAsyncResult result)
            {
                UserConnection connectionInfo = (UserConnection)result.AsyncState;
                int bytesRead = connectionInfo.userSocket.EndReceive(result);
                if (connectionInfo.messageBuffer[0] != 13 && connectionInfo.messageBuffer[1] != 10)
                //ascii for newline and line feed
                //todo dress this up
                {
                    if (string.IsNullOrEmpty(connectionInfo.message))
                    {
                        connectionInfo.message = ASCIIEncoding.ASCII.GetString(connectionInfo.messageBuffer);
                    }
                    else
                    {
                        connectionInfo.message += ASCIIEncoding.ASCII.GetString(connectionInfo.messageBuffer);
                    }
                }
                else
                {
                    connectionInfo.userSocket.Send(ASCIIEncoding.ASCII.GetBytes(connectionInfo.message), SocketFlags.None);
                    connectionInfo.userSocket.Send(connectionInfo.messageBuffer, SocketFlags.None);
                    connectionInfo.message = string.Empty;
                    connectionInfo.messageBuffer = new byte[_DATASIZE];
                }
    {
        public class UserConnection
        {
            public Socket userSocket { get; set; }
            public Byte[] messageBuffer { get; set; }
            public string message { get; set; }
        }
    }
