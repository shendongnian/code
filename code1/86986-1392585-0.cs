 /// Ассинхронный сервер 
 public class AsyncServer
 {
     /// Сокет сервера
     private Socket _serverSocket;
     /// Элемент для синхронизации ожидания подключений
     private static ManualResetEvent _connectionMutex =
              new ManualResetEvent(false);
     /// Менеджер для обработки клиентов
     private ClientManager _clientManager;
     public AsyncServer(string ipAddrees, int port)
     {
         try
         {
             // создание сокета для сервера
             this._serverSocket = new Socket(AddressFamily.InterNetwork,
                 SocketType.Stream, ProtocolType.Tcp);
             // прикрепление сервера к ip адресу и порту
             this._serverSocket.Bind(
               new IPEndPoint(IPAddress.Parse(ipAddrees), port));
         }
         catch (Exception ex)
         {
             throw new Exception("Ошибка инициализации сервера.", ex);
         }
     }
     private BackgroundWorker _listenThread = new BackgroundWorker();
     /// Начать работу сервера
     public void Start()
     {
         this._clientManager = new ClientManager(this._clientConnections);
         this._listenThread.WorkerReportsProgress = true;
         this._listenThread.WorkerSupportsCancellation = true;
         this._listenThread.DoWork +=
              new DoWorkEventHandler(ListenThread_DoWork);
         this._listenThread.RunWorkerAsync(this._serverSocket);
     }
     /// Поток для прослушки порта
     private void ListenThread_DoWork(object sender, DoWorkEventArgs e)
     {
         Socket serverSocket = (Socket)e.Argument;
         // прослушивание сокета
         serverSocket.Listen(100);
         while (true)
         {
             // сбросить мьютекс
             _connectionMutex.Reset();
          
             serverSocket.BeginAccept(
             new AsyncCallback(this.AcceptCallback), this._serverSocket);
             // ожидание следующего подключения
             _connectionMutex.WaitOne();
         }
     }
     /// Клиентские подключения
     private List _clientConnections = new List();
  
     /// Количество клиентских подключений     
     public int ConnectionsCount
     {
         get { return this._clientConnections.Count; }
     }
     /// Callback метод для обработки входящих соединений
     private void AcceptCallback(IAsyncResult asyncResult)
     {
         // уведомить о том, что подключение произошло
         _connectionMutex.Set();
         Socket serverSocket = (Socket)asyncResult.AsyncState;
         Socket clientSocket = (Socket)serverSocket.EndAccept(asyncResult);
         this._clientConnections.Add(clientSocket);
         // передача управления клиентом менеджеру клиентов
         this._clientManager.HandleClient(clientSocket);
     }
 }
