    public class Program
    {
        public static void Main(string[] args)
        {
            StartTcpListener("localhost", 9000);
        }
    
        private static byte[] SendReceiveRemoteServer(string host, int port, byte[] data)
        {
            try
            {
                // Create a TcpClient.
                // Note, for this client to work you need to have a TcpServer 
                // connected to the same address as specified by the server, port
                // combination.
                var client = new TcpClient(host, port);
    
                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();
    
                var stream = client.GetStream();
    
                // Send the message to the connected TcpServer. 
                stream.Write(data, 0, data.Length);
    
                Console.WriteLine("Sent to server: {0}", Encoding.ASCII.GetString(data));
    
                // Receive the TcpServer.response.
    
                // Read the first batch of the TcpServer response bytes.
                var bytes = new byte[256];
                var allBytes = new List<byte>();
                var i = stream.Read(bytes, 0, bytes.Length);
    
                // Loop to receive all the data sent by the client.
                while (i != 0)
                {
                    allBytes.AddRange(bytes);
    
                    bytes = new Byte[256];
                    i = stream.DataAvailable ? stream.Read(bytes, 0, bytes.Length) : 0;
                }
    
                Console.WriteLine("Received from server: {0}", Encoding.ASCII.GetString(data));
    
                // Close everything.
                stream.Close();
                client.Close();
    
                return allBytes.ToArray();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
    
            Console.WriteLine("\n Press Enter to continue...");
            return new byte[0];
        }
    
        private static void StartTcpListener(string host, int port)
        {
            TcpListener server = null;
            try
            {
                var ipHostInfo = Dns.GetHostEntry(host);
                var ipAddress = ipHostInfo.AddressList[0];
    
                // TcpListener server = new TcpListener(port);
                server = new TcpListener(ipAddress, port);
    
                // Start listening for client requests.
                server.Start();
    
                // Enter the listening loop.
                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");
    
                    // Perform a blocking call to accept requests.
                    // You could also user server.AcceptSocket() here.
                    var client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
    
                    // Get a stream object for reading and writing
                    var stream = client.GetStream();
    
                    // Buffer for reading data
                    var bytes = new Byte[256];
                    var allBytes = new List<byte>();
                    var i = stream.Read(bytes, 0, bytes.Length);
    
                    // Loop to receive all the data sent by the client.
                    while (i != 0)
                    {
                        allBytes.AddRange(bytes);
    
                        bytes = new Byte[256];
                        i = stream.DataAvailable ? stream.Read(bytes, 0, bytes.Length) : 0;
                    }
    
                    if (allBytes.Count > 0)
                    {
                        Console.WriteLine("Received from client: {0}", Encoding.ASCII.GetString(allBytes.ToArray()));
    
                        var received = SendReceiveRemoteServer("localhost", 11000, allBytes.ToArray());
    
                        // Send back a response.
                        stream.Write(received, 0, received.Length);
                        Console.WriteLine("Sent to client: {0}", Encoding.ASCII.GetString(received));
                    }
    
                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
    
            Console.WriteLine("\nHit enter to continue...");
        }
    }
