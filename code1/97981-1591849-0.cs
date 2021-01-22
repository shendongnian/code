    static void Main(string[] args)
        {
            Stream networkStream = null;
            string hostName = "pop.gmail.com";
            int port = 995;
            TcpClient client = new TcpClient();
            MemoryStream dataStream = new MemoryStream();
            try
            {
                
                client.SendTimeout = 15000;
                client.ReceiveTimeout = 15000;
                client.Connect(hostName, port);
                networkStream = new SslStream(client.GetStream(), true);
                ((SslStream)networkStream).AuthenticateAsClient(hostName);
                const int ChunkSize = 256;
                int bytesRead = 0;
                const int BufferSize = 1024;
                byte[] buffer = new byte[BufferSize];
                //CONNECT SHOULD GET BANNER
                string messageReceived;
                using (dataStream = new MemoryStream())
                {
                    do
                    {
                        bytesRead = networkStream.Read(buffer, 0, ChunkSize);
                        dataStream.Write(buffer, 0, bytesRead);
                        messageReceived = Encoding.UTF8.GetString(dataStream.ToArray());
                    } while (!messageReceived.EndsWith(Environment.NewLine));
                    Console.WriteLine("Response:{0}", Encoding.UTF8.GetString(dataStream.ToArray()));
                }
                buffer = Encoding.UTF8.GetBytes("USER test.net.user@gmail.com\r\n");
                networkStream.Write(buffer, 0, buffer.Length);
                buffer = new byte[BufferSize];
                using (dataStream = new MemoryStream())
                {
                    do
                    {
                        bytesRead = networkStream.Read(buffer, 0, ChunkSize);
                        dataStream.Write(buffer, 0, bytesRead);
                        messageReceived = Encoding.UTF8.GetString(dataStream.ToArray());
                    } while (!messageReceived.EndsWith(Environment.NewLine));
                    Console.WriteLine("Response:{0}", Encoding.UTF8.GetString(dataStream.ToArray()));
                }
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
            finally
            {
                if (networkStream != null)
                {
                    networkStream.Dispose();
                    networkStream = null;
                }
                if (client != null)
                {
                    if (client.Connected)
                    {
                        client.Client.Disconnect(false);
                    }
                    client.Close();
                    client = null;
                }
            }
            Console.ReadKey();
        }
