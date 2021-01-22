 /// Async server
 public class AsyncServer
 {
     /// Server socket
     private Socket _serverSocket;
     /// Element for sync wait 
     private static ManualResetEvent _connectionMutex =
              new ManualResetEvent(false);
     /// Client handler
     private ClientManager _clientManager;
     public AsyncServer(string ipAddrees, int port)
     {
         try
         {             
             this._serverSocket = new Socket(AddressFamily.InterNetwork,
                 SocketType.Stream, ProtocolType.Tcp);
             this._serverSocket.Bind(
               new IPEndPoint(IPAddress.Parse(ipAddrees), port));
         }
         catch (Exception ex)
         {
             throw new Exception("Server Init Error.", ex);
         }
     }
     private BackgroundWorker _listenThread = new BackgroundWorker();
     public void Start()
     {
         this._clientManager = new ClientManager(this._clientConnections);
         this._listenThread.WorkerReportsProgress = true;
         this._listenThread.WorkerSupportsCancellation = true;
         this._listenThread.DoWork +=
              new DoWorkEventHandler(ListenThread_DoWork);
         this._listenThread.RunWorkerAsync(this._serverSocket);
     }
     /// Thread for listening port
     private void ListenThread_DoWork(object sender, DoWorkEventArgs e)
     {
         Socket serverSocket = (Socket)e.Argument;
         serverSocket.Listen(100);
         while (true)
         {
             // reset mutex
             _connectionMutex.Reset();
          
             serverSocket.BeginAccept(
             new AsyncCallback(this.AcceptCallback), this._serverSocket);
             // waiting for the next connection
             _connectionMutex.WaitOne();
         }
     }
     /// List of client connections
     private List _clientConnections = new List();  
     public int ConnectionsCount
     {
         get { return this._clientConnections.Count; }
     }
     /// Callback method for handling connections
     private void AcceptCallback(IAsyncResult asyncResult)
     {
         _connectionMutex.Set();
         Socket serverSocket = (Socket)asyncResult.AsyncState;
         Socket clientSocket = (Socket)serverSocket.EndAccept(asyncResult);
         this._clientConnections.Add(clientSocket);
         this._clientManager.HandleClient(clientSocket);
     }
 }
