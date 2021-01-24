      class MyTcpListener
        {
            public static void Listen()
            {
                TcpListener server = null;
                byte[] bytes = new byte[256];
                try
                {
                    // Set the TcpListener on port 13000.
                    const int port = 13000;
                    IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                    // TcpListener server = new TcpListener(port);
                    server = new TcpListener(localAddr, port);
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
                        NetworkStream stream = client.GetStream();
                        int i;
                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Console.WriteLine($"Received: {data}");
                            // Process the data sent by the client.
                            data = data.ToUpper();
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            Console.WriteLine($"Sent: {data}");
                        }
                        // Shutdown and end connection
                        client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e}");
                }
                finally
                {
                    // Stop listening for new clients.
                    server?.Stop();
                }
            }
        }
