      public class Server
      {
        private static readonly TcpListener listener = new TcpListener(IPAddress.Any, 9999);
        public Server()
        {
          listener.Start();
          Console.WriteLine("Started.");
          while (true)
          {
            Console.WriteLine("Waiting for connection...");
            var client = listener.AcceptTcpClient();
            Console.WriteLine("Connected!");
            // each connection has its own thread
            new Thread(ServeData).Start(client);
          }
        }
        private static void ServeData(object clientSocket)
        {
          Console.WriteLine("Started thread " + Thread.CurrentThread.ManagedThreadId);
          var rnd = new Random();
          try
          {
            var client = (TcpClient) clientSocket;
            var stream = client.GetStream();
            while (true)
            {
              if (rnd.NextDouble() < 0.1)
              {
                var msg = Encoding.ASCII.GetBytes("Status update from thread " + Thread.CurrentThread.ManagedThreadId);
                stream.Write(msg, 0, msg.Length);
                Console.WriteLine("Status update from thread " + Thread.CurrentThread.ManagedThreadId);
              }
              // wait until the next update - I made the wait time so small 'cause I was bored :)
              Thread.Sleep(new TimeSpan(0, 0, rnd.Next(1, 5)));
            }
          }
          catch (SocketException e)
          {
            Console.WriteLine("Socket exception in thread {0}: {1}", Thread.CurrentThread.ManagedThreadId, e);
          }
        }
      }
