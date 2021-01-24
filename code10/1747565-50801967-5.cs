    public class AsynchronousSocketServer
    {
        private Socket listener;
        private byte[] buffer = new byte[8192]; // Buffer to store data from clients.
        
        public void StartListening()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(localIPAddress, listeningPort));
            listener.Listen(20);
            listener.BeginAccept(OnSocketAccepted, null);
        }
        private void OnSocketAccepted(IAsyncResult result)
        {
            // This is the client socket, where you send/receive data from after accepting. Keep it in a List<Socket> collection if you need to.
            Socket client = listener.EndAccept(result);
            // Pass in the client socket as the state object, so you can access it in the callback.
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnDataReceived, client); // Start receiving data from this client.
            listener.BeginAccept(OnSocketAccepted, null); // Start a new async accept operation to accept incoming connections from other clients.
        }
        private void OnDataReceived(IAsyncResult result)
        {
            // This is the client that sent you data. AsyncState is exactly what you passed into the state parameter in BeginReceive
            Socket client = result.AsyncState as Socket;
            int received = client.EndReceive(result);
            // Handle received data in buffer, send reply to client etc...
            // Start a new async receive on the client to receive more data.
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnDataReceived, client);
        }
    }
