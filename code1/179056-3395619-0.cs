    public class TcpDataTransportClient : IDataTransportService
    {
        private const string TCP_ADDRESS_SETTING = "tcpaddress";
        private const string TCP_PORT_SETTING = "tcpport";
    
        private Dictionary<string, object> settings = new Dictionary<string, object>();
        private IDataEncapsulator dataEncapsulator;
        private IDataCollector dataCollector;
                    
        private Socket client;
        private SocketAsyncEventArgs clientArgs;
    
        public event DataReceivedHandler OnDataReceived;
        public event DataSentHandler OnDataSent;
    
        AutoResetEvent clientDataSent = new AutoResetEvent(false);
        AutoResetEvent clientConnected = new AutoResetEvent(false);
    
        public TcpDataTransportClient()
        {
                
        }
    
        public Dictionary<string, object> Settings
        {
            get
            {
                return this.settings;
            }
            set
            {
                this.settings = value;
            }
        }
    
        public IDataEncapsulator DataEncapsulator
        {
            get
            {
                return this.dataEncapsulator;
            }
            set
            {
                this.dataEncapsulator = value;
            }
        }
                    
        public void Start(IDataCollector dataCollector)
        {
            this.dataCollector = dataCollector;
            clientArgs = new SocketAsyncEventArgs();
    
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientArgs.Completed += clientArgs_Completed;
            clientArgs.UserToken = client;            
            clientArgs.RemoteEndPoint = GetIPEndPoint();
                           
            client.ConnectAsync(clientArgs);
            clientConnected.WaitOne();            
        }
    
        private IPEndPoint GetIPEndPoint()
        {
            IPAddress ipAddress;
            int tcpPort;
    
            if (!IPAddress.TryParse(settings[TCP_ADDRESS_SETTING].ToString(), out ipAddress))
                throw new ArgumentException(String.Format("Invalid setting for IP Address: '{0}'", TCP_ADDRESS_SETTING));
    
            if (!int.TryParse(settings[TCP_PORT_SETTING].ToString(), out tcpPort))
                throw new ArgumentException(String.Format("Invalid setting for TCP Port: '{0}'", TCP_PORT_SETTING));
    
            return new IPEndPoint(ipAddress, tcpPort);
        }
    
        void clientArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            switch (e.LastOperation)
            {
                case SocketAsyncOperation.Connect:
                    ProcessConnect(e);
                    break;
                case SocketAsyncOperation.Receive:
                    ProcessReceive(e);
                    break;
                case SocketAsyncOperation.Send:
                    ProcessSend(e);
                    break;
                default:
                    throw new Exception("Invalid operation completed");
            }
        }
    
        private void ProcessConnect(SocketAsyncEventArgs e)
        {
            if (e.SocketError != SocketError.Success)
            {
                throw new SocketException((int)e.SocketError);
            }
            else
            {
                clientConnected.Set();
            }
        }
    
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                var socket = e.UserToken as Socket;
    
                var response = dataCollector.Collect(e.Buffer);
    
                if (response != null)
                {
                    if (this.OnDataReceived != null)
                        this.OnDataReceived(response);
                }
                else
                {
                    bool willRaiseEvent = socket.ReceiveAsync(clientArgs);
                    if (!willRaiseEvent)
                        ProcessReceive(e);
                }
            }
            else
            {
                throw new SocketException((int)e.SocketError);
            }
        }
    
        private void ProcessSend(SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {                
                var socket = e.UserToken as Socket;
                    
                if (OnDataSent != null)
                    OnDataSent(clientArgs.Buffer);
    
                bool willRaiseEvent = socket.ReceiveAsync(e);
                if (!willRaiseEvent)
                    ProcessReceive(e);
    
                clientDataSent.Set();
            }
            else
            {
                throw new SocketException((int)e.SocketError);
            }
        }
                       
    
        public void Stop()
        {            
            client.Shutdown(SocketShutdown.Send);
            client.Close();
            client.Dispose();
            clientArgs.Dispose();           
        }
    
        public void Write(byte[] data)
        {          
            clientArgs.SetBuffer(data, 0, data.Length);
                
            bool willRaiseEvent = client.SendAsync(clientArgs);
            if (!willRaiseEvent)
                ProcessSend(clientArgs);
    
            clientDataSent.WaitOne();
        }
    }
