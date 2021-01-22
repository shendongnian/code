    class MyTcpListener
    {
        public static void Main()
        {
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 80;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                // TcpListener server = new TcpListener(port);
                TcpListener server = new TcpListener(localAddr, port);
                // Start listening for client requests.
                server.Start();
                // Enter the listening loop.
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    // Get a stream object for reading and writing
                    using(NetworkStream stream = client.GetStream())
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        List<byte> msg = new List<byte>();
                        // Loop to receive all the data sent by the client.
                        string data;
                        while ((data = sr.ReadLine()) != "")
                        {
                            Console.WriteLine(String.Format("Received: {0}", data));
                            // Process the data sent by the client.
                            data = data.ToUpper();
                            msg.AddRange(System.Text.Encoding.ASCII.GetBytes(data));
                        }
                        // Send back a response.
                        stream.Write(msg.ToArray(), 0, msg.Count);
                        Console.WriteLine("Sending message..");
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
