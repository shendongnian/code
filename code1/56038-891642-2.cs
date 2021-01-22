      public class Client
      {
        public Client()
        {
          var client = new TcpClient();
          client.Connect(IPAddress.Loopback, 9999);
          var msg = new byte[1024];
          var stream = client.GetStream();
          try
          {
            while (true)
            {
              int i;
              while ((i = stream.Read(msg, 0, msg.Length)) != 0)
              {
                var data = Encoding.ASCII.GetString(msg, 0, i);
                Console.WriteLine("Received: {0}", data);
              }
            }
          }
          catch (SocketException e)
          {
            Console.WriteLine("Socket exception in thread {0}: {1}", Thread.CurrentThread.ManagedThreadId, e);
          }
        }
      }
