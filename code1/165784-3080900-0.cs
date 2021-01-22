    public sealed class TcpConnection
    {
        private readonly int port;
        public int Port { get { return port; } }
        
        // Or use one of the types from System.Net
        private readonly string ipAddress;
        public string IpAddress { get { return ipAddress; } }
        
        private readonly int retryCount;
        public int RetryCount { get { return retryCount; } }
        
        // etc
        
        public TcpConnection(XElement element)
        {
            // Extract the fields here
        }
    }
