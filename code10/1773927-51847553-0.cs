    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;
    namespace ConsoleApplication1
    {
        public class AsynchIOServer
        {
            public class State
            {
                public TcpListener listener { get; set; }
                public string buffer = "";
            }
            static void Listeners(State state)
            {
                using (Socket socketForClient = state.listener.AcceptSocket())
                {
                    if (socketForClient.Connected)
                    {
                        Console.WriteLine("Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                        using (NetworkStream networkStream = new NetworkStream(socketForClient))
                        using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(networkStream))
                        using (System.IO.StreamReader streamReader = new System.IO.StreamReader(networkStream))
                        {
                            try
                            {
                                while (true)
                                {
                                    string theString = streamReader.ReadLine();
                                    if (string.IsNullOrEmpty(theString) == false)
                                    {
                                        Console.WriteLine("Message recieved by  " + theString);
                                        var result = theString.Split(',');
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }
                        }
                    }
                }
                Console.WriteLine("Press any key to exit from server program");
                Console.ReadKey();
            }
            public static void Main()
            {
                State[] states = new State[2];
                
                Console.WriteLine("***********This is Server program***********");
                Console.WriteLine("How many clients are going to connect to this server?:");
                int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
                foreach (State state in states)
                {
                    state.listener.Start();
                    for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
                    {
                        Thread newThread = new Thread(new ParameterizedThreadStart(Listeners));
                        newThread.Start(state.listener);
                    }
                }
            }
        } 
    }
