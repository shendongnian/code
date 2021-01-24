    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 6666);
            serverListener.Start();
            TcpClient tcpClient = serverListener.AcceptTcpClient();
            Console.WriteLine(">>> Receiving");
            byte[] clientBuffer;
            using (NetworkStream clientNStream = tcpClient.GetStream())
            {
                int i;
                string received = "";
                byte[] integerBytes = new byte[sizeof(int)];
                clientNStream.Read(integerBytes, 0, integerBytes.Length); // receive message length
                int messageLength = BitConverter.ToInt32(integerBytes, 0);
                Console.WriteLine("Received message length: {0}", messageLength);
                clientBuffer = new byte[messageLength]; // allocate buffer
                clientNStream.Read(clientBuffer, 0, clientBuffer.Length); // read string contents
                Console.WriteLine("Received all the data");
                // we're done
                Console.WriteLine("Closing connection");
                tcpClient.Close();
                received = Encoding.ASCII.GetString(clientBuffer, 0, clientBuffer.Length);
                File.WriteAllText(@"E:\receivedData.txt", received);
                Console.WriteLine(">>>Done");
            }
        }
    }
