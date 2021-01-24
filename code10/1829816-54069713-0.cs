    /// <summary>
    /// This class encapsulates the TCP server
    /// </summary>
    public class Server : IDisposable
    {
        private static TcpListener _listener;
        private static TcpClient _client;
        private static NetworkStream _stream;
        private static byte[] _buffer;
        private static readonly StringBuilder _receivedText = new StringBuilder();
        private const string EOF = "<EOF>";
        /// <summary>
        /// Starts listening on the specified port
        /// </summary>
        /// <param name="port">The port number</param>
        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Start();
            _listener.BeginAcceptTcpClient(Accepted, null);
        }
        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
            if (_listener != null)
            {
                _listener.Stop();
            }
        }
        /// <summary>
        /// Returns any text that has been sent via TCP to the port specified in the constructor.
        /// </summary>
        /// <returns>The received text, or null if no (complete) text has been received yet.</returns>
        /// <remarks>
        /// The method returns the next text delimited by "&lt;EOF&gt;".
        /// </remarks>
        public string Read()
        {
            lock (_receivedText)
            {
                var receivedText = _receivedText.ToString();
                var eofIndex = receivedText.IndexOf(EOF);
                if (eofIndex < 0)
                    return null; // no (complete) text has been received yet
                var result = receivedText.Substring(0, eofIndex);
                _receivedText.Remove(0, eofIndex + EOF.Length);
                return result;
            }
        }
        // called whenever a client has connected to our server.
        private static void Accepted(IAsyncResult ar)
        {
            _client = _listener.EndAcceptTcpClient(ar);
            _stream = _client.GetStream();
            _buffer = new byte[4096];
            _stream.BeginRead(_buffer, 0, _buffer.Length, Read, null);
        }
        // called whenever data has arrived or if the client closed the TCP connection
        private static void Read(IAsyncResult ar)
        {
            var bytesReceived = _stream.EndRead(ar);
            if (bytesReceived == 0)
            {
                // TCP connection closed
                _client.Close();
                _client = null;
                _stream.Dispose();
                _stream = null;
                // prepare for accepting the next TCP connection
                _listener.BeginAcceptTcpClient(Accepted, null);
                return;
            }
            lock (_receivedText)
            {
                _receivedText.Append(Encoding.ASCII.GetString(_buffer, 0, bytesReceived));
            }
            // prepare for reading more
            _stream.BeginRead(_buffer, 0, _buffer.Length, Read, null);
        }
    }
