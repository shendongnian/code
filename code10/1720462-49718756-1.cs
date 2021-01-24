        class MyTCPClient
        {
            static void Connect(String server, String message)
            {
                try
                {
                    // Create a TcpClient.
                    // Note, for this client to work you need to have a TcpServer 
                    // connected to the same address as specified by the server, port
                    // combination.
                    int port = 13000;
                    TcpClient client = new TcpClient(server, port);
    
                    // Translate the passed message into ASCII and store it as a Byte array. Any encoding can be used as long as it's consistent with the server.
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
    
                    // Get a client stream for reading and writing.
                    //  Stream stream = client.GetStream();
                    NetworkStream stream = client.GetStream();
    
                    // Send the message to the connected TcpServer. 
                    stream.Write(data, 0, data.Length);
                    Console.WriteLine($"Sent: {message}");
    
                    // Receive the TcpServer.response. This is all optional and can be removed if you aren't recieving a response.
                    // Buffer to store the response bytes.
                    data = new byte[256];
    
                    // String to store the response ASCII representation.
    
                    // Read the first batch of the TcpServer response bytes.
                    int bytes = stream.Read(data, 0, data.Length);
                    string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {responseData}");
    
                    // Close everything.
                    stream?.Close();
                    client?.Close();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"ArgumentNullException: {e}");
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"SocketException: {e}");
                }
    
                Console.WriteLine("\n Press Enter to continue...");
                Console.Read();
            }
        }
        
    }
