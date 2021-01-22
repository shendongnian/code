    public class HTTPRequestFactory3
    {
    internal ISocket _socket;
        /// <summary>
        /// Creates a socket and sends/receives information.  Used for mocking to inject ISocket
        /// </summary>
        internal HTTPRequestFactory3(ISocket TheSocket)
        {
         _socket = TheSocket as ISocket;
         this.Setup();
        }
        /// <summary>
        /// Self Injects a new Socket.
        /// </summary>
        public  HTTPRequestFactory3()
        {
            SocketWrapper theSocket = new SocketWrapper();
            _socket = theSocket as ISocket;
            this.Setup();
        }
    }
