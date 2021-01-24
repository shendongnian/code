    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Sockets;
    using System.Threading;
    
    namespace DemoServer.Models
    {
        public class Receiver : ModelBase
        {
            bool ConnectionStatus = false;
    
            private uint m_Id = 0;
            public uint Id
            {
                get { return m_Id; }
                set => SetAndRaisePropertyChanged(ref m_Id, value);
            }
    
            private Thread receivingThread;
            private Thread sendingThread;
            public Server Server { get; set; }
            public TcpClient Client { get; set; }
            public List<String> MessageQueue { get; private set; }
    
    
            public Receiver(TcpClient client, Server server)
            {
                MessageQueue = new List<String>();
                Server = server;
                Client = client;
                Client.ReceiveBufferSize = 1024;
                Client.SendBufferSize = 1024;
                ConnectionStatus = true;
            }
    
            public void Start()
            {
                receivingThread = new Thread(ReceivingMethod);
                receivingThread.IsBackground = true;
                receivingThread.Start();
    
                sendingThread = new Thread(SendingMethod);
                sendingThread.IsBackground = true;
                sendingThread.Start();
            }
    
            private void Disconnect()
            {
                if (!ConnectionStatus) return;
                ConnectionStatus = false;
                Client.Client.Disconnect(false);
                Client.Close();
            }
    
           
            private void SendingMethod()
            {
                while (ConnectionStatus)
                {
                    if (MessageQueue.Count > 0)
                    {
                        var message = MessageQueue[0];
                        try
                        {
                            NetworkStream clientStream = Client.GetStream();
                            StreamWriter streamWriter = new StreamWriter(clientStream);
                            streamWriter.Write(message);
                            streamWriter.Flush();
                            Console.WriteLine($"We are sending '{message}' to the client");
                        }
                        catch
                        {
                            Disconnect();
                        }
                        finally
                        {
                            MessageQueue.RemoveAt(0);
                        }
                    }
                    Thread.Sleep(30);
                }
            }
    
            private void ReceivingMethod()
            {
                while (ConnectionStatus)
                {
                    if (Client.Available > 0)
                    {
                        try
                        {
                            NetworkStream clientStream = Client.GetStream();
                            StreamReader streamReader = new StreamReader(clientStream);
                            char[] puchBuffer = new char[Client.Available];
                            int iQtt = streamReader.Read(puchBuffer, 0, Client.Available);
                            string msg = String.Empty;
                            for (int i = 0; i < puchBuffer.Length; i++)
                            {
                                msg = $"{msg}{Convert.ToString(puchBuffer[i])}";
                            }
                            OnMessageReceived(msg);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    Thread.Sleep(30);
                }
            }
    
            private void OnMessageReceived(String msg)
            {
                // Here you can parse the messages coming ffrom the client and do whatever is needed
                // If needed, you can even call some public methods from the server to forward some info to an other client for example or just the server:
                // eg: Server.SomeInteractionBetweenClients();
            }
        }
    }
