      //tcp server
    public class Server
    {
        private string ip { get; set; }
        private int port { get; set; }
        private Socket server { get; set; }
        public List<ClientInfo> listClientsConnected { get; private set; }
        // delegate for events
        public delegate void Client_Connected(ClientInfo c);
        public delegate void Client_Message(string msg, ClientInfo c);
        public Server(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            this.listClientsConnected = new List<ClientInfo>();
        }
        // start server
        public void Start()
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Parse(this.ip), this.port));
            server.Listen(1);
            server.BeginAccept(new AsyncCallback(ClientConnected), server);
        }
        // accept client connection
        private void ClientConnected(IAsyncResult res)
        {
            Socket s = (Socket)res.AsyncState;
            Socket client = s.EndAccept(res);
            ClientInfo clientInf = new ClientInfo()
            {
                currentClient = client
            };
            client.BeginReceive(clientInf.buffer, 0, ClientInfo.BUFFER_SIZE_FOR_MESSAGE, 0, new AsyncCallback(ReceiveMessage), clientInf);
            // add client to list
            listClientsConnected.Add(clientInf);
            if (Cliente_Conneted_Event != null)
                Cliente_Conneted_Event(clientInf);
        }
        // receive message from client
        private void ReceiveMessage(IAsyncResult ar)
        {
            ClientInfo cl = (ClientInfo)ar.AsyncState;
            Socket s = cl.currentClient;
            int read = s.EndReceive(ar);
            string msg = null;
            if (read > 0)
            {
                msg = Encoding.ASCII.GetString(cl.buffer, 0, read);
                s.BeginReceive(cl.buffer, 0, ClientInfo.BUFFER_SIZE_FOR_MESSAGE, 0, new AsyncCallback(ReceiveMessage), cl);
            }
            if (Cliente_Message_Event != null)
                Cliente_Message_Event(msg, cl);
        }
        // send message to client
        public void sendMessage(string msg, ClientInfo client)
        {
            if (client.currentClient != null)
            {
                if (client.currentClient.Connected && !string.IsNullOrEmpty(msg))
                {
                    client.currentClient.Send(Encoding.ASCII.GetBytes(msg));
                }
            }
        }
        //events
        public event Client_Connected Cliente_Conneted_Event;
        public event Client_Message Cliente_Message_Event;
    }
  
      // tcp client
    public class Client
    {
        private Socket client { get; set; }
        private string clientName { get; set; }
        private string ip { get; set; }
        private int port { get; set; }
        // delegates
        public delegate void Client_Connected(ClientInfo c);
        public delegate void Client_Message(string msg, ClientInfo c);
        public Client(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        // connect client to server
        public void Connect()
        {
            ClientInfo clientInf = new ClientInfo()
            {
                currentClient = client,
            };
            client.BeginConnect(new IPEndPoint(IPAddress.Parse(this.ip), this.port), new AsyncCallback(ClientConnected), clientInf);
        }
        // accept client connection
        private void ClientConnected(IAsyncResult res)
        {
            ClientInfo clientInf = (ClientInfo)res.AsyncState;
            clientInf.currentClient.BeginReceive(clientInf.buffer, 0, ClientInfo.BUFFER_SIZE_FOR_MESSAGE, 0, new AsyncCallback(ReceiveMessage), clientInf);
            // client connected
            if (Cliente_Conneted_Event != null)
                Cliente_Conneted_Event(clientInf);
        }
        // receive message from client
        private void ReceiveMessage(IAsyncResult ar)
        {
            ClientInfo cl = (ClientInfo)ar.AsyncState;
            Socket s = cl.currentClient;
            int read = s.EndReceive(ar);
            string msg = null;
            if (read > 0)
            {
                msg = Encoding.ASCII.GetString(cl.buffer, 0, read);
                s.BeginReceive(cl.buffer, 0, ClientInfo.BUFFER_SIZE_FOR_MESSAGE, 0, new AsyncCallback(ReceiveMessage), cl);
            }
            if (Cliente_Message_Event != null)
                Cliente_Message_Event(msg, cl);
        }
        // send message to client
        public void sendMessage(string msg, ClientInfo client)
        {
            if (client.currentClient != null)
            {
                if (client.currentClient.Connected && !string.IsNullOrEmpty(msg))
                {
                    client.currentClient.Send(Encoding.ASCII.GetBytes(msg));
                }
            }
        }
        public event Client_Connected Cliente_Conneted_Event;
        public event Client_Message Cliente_Message_Event;
    }
      // in my case i used a console application
    class Program
    {
        private static Server server;
        static void Main(string[] args)
        {
            string ip = "127.0.0.1";
            int port = 3122;
            server = new Server(ip, port);
            server.Cliente_Conneted_Event += server_Cliente_Conneted_Event;
            server.Start();
            // connect client 1
            Client client = new Client(ip, port);
            client.Connect();
            client.Cliente_Message_Event+=client_Cliente_Message_Event;
            sendMessageToClient();
            Console.ReadKey();
        }
        //receive message from server
        private static void client_Cliente_Message_Event(string msg, ClientInfo c)
        {
            try {
                Console.WriteLine("Msg from Server:"+msg);
            }
            catch(Exception ex){
                Console.WriteLine(ex.Message);
            }
        }
        // client connected to server
        private static void server_Cliente_Conneted_Event(ClientInfo c)
        {
            Console.WriteLine("Client Connected...");
        }
        // send message to all clients from server
        private static void sendMessageToClient()
        {
            try
            {
                Console.Write("Msg:");
                string msg = Console.ReadLine();
                // send message to clients
                if (server.listClientsConnected.Count > 0)
                {
                    foreach (ClientInfo client in server.listClientsConnected)
                        server.sendMessage(msg, client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sendMessageToClient();
            }
        }
    }
