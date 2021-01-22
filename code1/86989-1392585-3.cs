   public class ClientManager
   {       
       private List<BackgroundWorker> _clientProcessors = new List<BackgroundWorker>();
      
       private List<Socket> _connections;       
       public ClientManager(List<Socket> connections)
       {
           this._connections = connections;
       }
      
       /// Handling of client connection      
       public void HandleClient(Socket clientSocket)
       {
           BackgroundWorker clientProcessor = new BackgroundWorker();
           clientProcessor.DoWork += new DoWorkEventHandler(ClientProcessing);
           this._clientProcessors.Add(clientProcessor);
           List<object> args = new List<object>();
           // 
           // args.Add(...);           
           clientProcessor.RunWorkerAsync(args);
       }      
       private void ClientProcessing(object sender, DoWorkEventArgs e)
       {
           // reading args
           List<object> args = (List<object>)e.Argument;          
           ProtocolSerializer serializer = new ProtocolSerializer();
           try
           {
               while (socket.Connected)
               {               
                   // ...
                 
               }
           }
           catch (SocketException)
           {
              // ...
           }
           catch (Exception)
           {
              // ...
           }
       }
   }
