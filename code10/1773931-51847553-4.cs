    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;
    using System.IO;
    namespace ConsoleApplication1
    {
        public class AsynchIOServer
        {
            public class State
            {
                public TcpListener listener { get; set; }
                public StreamReader streamReader { get; set; }
                public StreamWriter streamWriter { get; set; }
                public NetworkStream networkStream { get; set; }
                public Socket socketForClient { get; set; }
            }
            static void Listeners(object obj)
            {
                State state = obj as State;
                using (state.socketForClient = state.listener.AcceptSocket())
                {
                    if (state.socketForClient.Connected)
                    {
                        Console.WriteLine("Client:" + state.socketForClient.RemoteEndPoint + " now connected to server.");
                        using (state.networkStream = new NetworkStream(state.socketForClient))
                        using (state.streamWriter = new System.IO.StreamWriter(state.networkStream))
                        using (state.streamReader = new System.IO.StreamReader(state.networkStream))
                        {
                            try
                            {
                                while (true)
                                {
                                    string theString = state.streamReader.ReadLine();
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
                State[] states = new State[] {
                    new State() { listener = new TcpListener(15)},
                    new State() { listener = new TcpListener(10)}
                };
                
                Console.WriteLine("***********This is Server program***********");
                Console.WriteLine("How many clients are going to connect to this server?:");
                int numberOfClientsYouNeedToConnect = int.Parse(Console.ReadLine());
                foreach (State state in states)
                {
                    state.listener.Start();
                    for (int i = 0; i < numberOfClientsYouNeedToConnect; i++)
                    {
                        Thread newThread = new Thread(new ParameterizedThreadStart(Listeners));
                        newThread.Start(state);
                    }
                }
            }
        } 
    }
