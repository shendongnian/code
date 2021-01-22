      public class Server
      {
        public void Serve(IPAddress address, int port)
        {
    
          TcpListener listener = new TcpListener(address, port);
          listener.Start();
          while (true)
          {
            TcpClient c = listener.AcceptTcpClient();
            Task.Factory.StartNew(Accept, c);
          }
        }
    
        void Accept(object clientObject)
        {
          using (TcpClient client = (TcpClient)clientObject)
          {
            using (NetworkStream n = client.GetStream())
            {
              byte[] data = new byte[5000];
    
              int bytesRead = 0; int chunkSize = 1;
    
              while (bytesRead < data.Length && chunkSize > 0)
              {
                bytesRead +=
                  chunkSize = n.Read /// Read is blocking
                    (data, bytesRead, data.Length - bytesRead);
              }
    
              Array.Reverse(data);
              n.Write                /// Write is blocking
                (data, 0, data.Length);
            }
          }
        }
      }
