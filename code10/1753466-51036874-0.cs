     public class Parameters
     {
        public Socket _socket;
        public string content;
     }
    //calling part
      Thread listenerThread = new Thread(new ParameterizedThreadStart(SendTCPServer));
            Socket newsock = new
               Socket(AddressFamily.InterNetwork,
                           SocketType.Stream, ProtocolType.Tcp);
            listenerThread.Start(new Parameters { _socket = newsock, content = "Welcome" 
     });
            Thread.Sleep(60000);
                newsock.Dispose();
    //calling part end
     public static void SendTCPServer(object obj)
        {
            try
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();
                byte[] data = new byte[1024];
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any,
                                       8080);
                Parameters param = obj as Parameters;
                Socket newsock = param._socket;
                newsock.Bind(ipep);
                newsock.Listen(10);
                while (timer.Elapsed.TotalSeconds < 60)
                {
                    Console.WriteLine("Waiting for a client...");
                    Socket client = newsock.Accept();
                    IPEndPoint clientep =
                                 (IPEndPoint)client.RemoteEndPoint;
                    Console.WriteLine("Connected with {0} at port {1}",
                                    clientep.Address, clientep.Port);
                    string welcome = param.content;
                    data = Encoding.ASCII.GetBytes(welcome);
                    client.Send(data, data.Length,
                                      SocketFlags.None);
                    Console.WriteLine("Disconnected from {0}",
                                      clientep.Address);
                    client.Close();
                    newsock.Close();
                    return;
                }
                timer.Stop();
                //client.Close();
                newsock.Close();
                return;
            }
            catch (Exception ex)
            {
                
            }
          
        }
