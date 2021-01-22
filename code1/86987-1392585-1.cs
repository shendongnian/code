   /// Менеджер для работы с клиентским подключениями   
   public class ClientManager
   {       
       /// Коллекция процессоров клиентов       
       private List<BackgroundWorker> _clientProcessors = new List<BackgroundWorker>();
      
       /// Коллекция соединений       
       private List<Socket> _connections;       
       /// <param name="connections">Список соединений</param>
       public ClientManager(List<Socket> connections)
       {
           this._connections = connections;
       }
      
       /// Обработка клиентского подключения               
       public void HandleClient(Socket clientSocket)
       {
           BackgroundWorker clientProcessor = new BackgroundWorker();
           clientProcessor.DoWork += new DoWorkEventHandler(ClientProcessing);
           // добавление процессора в коллекцию процессоров
           this._clientProcessors.Add(clientProcessor);
           List<object> args = new List<object>();
           // добавление аргументов для потока
           // args.Add(...);           
           // запустить процессор для обработки клиента
           clientProcessor.RunWorkerAsync(args);
       }
      
       /// Метод для работы с клиентом в другом потоке               
       private void ClientProcessing(object sender, DoWorkEventArgs e)
       {
           // чтение аргументов
           List<object> args = (List<object>)e.Argument;          
           ProtocolSerializer serializer = new ProtocolSerializer();
           try
           {
               while (socket.Connected)
               {               
                   // получение или отправка данных
                 
               }
           }
           catch (SocketException)
           {
              // обработка исключений
           }
           catch (Exception)
           {
              // обработка исключений
           }
       }
   }
