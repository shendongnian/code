    class Program
    {
        static void Main(string[] args)
        {
            Socket socket;
            int GroupPort = 30718;
            try
            {
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
                var localEP = new IPEndPoint(IPAddress.Parse("10.0.2.14"), GroupPort);    // <-- your local IP address
                socket.Bind(localEP);
                socket.ReceiveTimeout = 200;
            }
            catch (TimeoutException e)
            {
                Console.WriteLine("Failed to create socket. " + e.Message);
                return;
            }
            var remoteEP = new IPEndPoint(IPAddress.Broadcast, GroupPort);
            try
            {
                byte[] messageBytes;
                messageBytes = new byte[0];
                messageBytes = AddByteToArray(messageBytes, 0xf6);
                messageBytes = AddByteToArray(messageBytes, 0);
                messageBytes = AddByteToArray(messageBytes, 0);
                messageBytes = AddByteToArray(messageBytes, 0);
                socket.SendTo(messageBytes, remoteEP);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to send message. " + e.Message);
                return;
            }
            var recvEp = (EndPoint)new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    var recvBytes = new byte[1024];
                    var receivedCount = socket.ReceiveFrom(recvBytes, ref recvEp);
                    var receivedArray = recvBytes.Take(receivedCount).ToArray();
                    var receivedArrayAsHexString = string.Join("", receivedArray.Select(c => String.Format("{0:X2}", Convert.ToInt32(c))));
                    string returnData = Encoding.ASCII.GetString(receivedArray);
                    Console.WriteLine($"Broadcast Respond from client {recvEp.ToString()} returned: {receivedArrayAsHexString}");
                }
                catch (Exception e)
                {
                    socket.Close();
                    break;
                }
            }
            Console.ReadLine();
        }
        public static byte[] AddByteToArray(byte[] bArray, byte newByte)
        {
            byte[] newArray = new byte[bArray.Length + 1];
            bArray.CopyTo(newArray, 1);
            newArray[0] = newByte;
            return newArray;
        }
    }
