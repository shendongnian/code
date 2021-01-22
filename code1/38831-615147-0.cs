    public class HSTcpServer
    {
        private TcpListener m_listener;
        private IPAddress m_address = IPAddress.Any;
	    private int m_port;
	    private bool m_listening;   
	    private object m_syncRoot = new object();
        public event EventHandler<TcpMessageReceivedEventArgs> MessageReceived;
        
	    public HSTcpServer(int port)
	    {
	        m_port = port;
	    }
        public IPAddress Address
        {
            get { return m_address; }
        }
        public int Port
        {
            get { return m_port; }
        }
        public bool Listening
        {
            get { return m_listening; }
        }
        public void Listen()
        {
            try
            {
                lock (m_syncRoot)
                {
                    m_listener = new TcpListener(m_address, m_port);
                    // fire up the server
                    m_listener.Start();
                    // set listening bit
                    m_listening = true;
                }
                // Enter the listening loop.
                do
                {
                    Trace.Write("Looking for someone to talk to... ");
                    // Wait for connection
                    TcpClient newClient = m_listener.AcceptTcpClient();
                    //Trace.WriteLine("Connected to new client");
                    // queue a request to take care of the client
                    ThreadPool.QueueUserWorkItem(new WaitCallback(ProcessClient), newClient);
                }
                while (m_listening);
            }
            catch (SocketException se)
            {
                Trace.WriteLine("SocketException: " + se.ToString());
            }
            finally
            {
                // shut it down
                StopListening();
            }
        }
        public void StopListening()
        {
            if (m_listening)
            {
                lock (m_syncRoot)
                {
                    // set listening bit
                    m_listening = false;
                    // shut it down
                    m_listener.Stop();
                }
            }
        }
        private void sendMessage(string message)
        {
            // Copy to a temporary variable to be thread-safe.
            EventHandler<TcpMessageReceivedEventArgs> messageReceived = MessageReceived;
            if (messageReceived != null)
                messageReceived(this, new TcpMessageReceivedEventArgs(message));
        }
        private void ProcessClient(object client)
        {
            TcpClient newClient = (TcpClient)client;
            try
            {
                // Buffer for reading data
                byte[] bytes = new byte[1024];
                StringBuilder clientData = new StringBuilder();
                // get the stream to talk to the client over
                using (NetworkStream ns = newClient.GetStream())
                {
                    // set initial read timeout to 1 minute to allow for connection
                    ns.ReadTimeout = 60000;
                    // Loop to receive all the data sent by the client.
                    int bytesRead = 0;
                    do
                    {
                        // read the data
                        try
                        {
                            bytesRead = ns.Read(bytes, 0, bytes.Length);
                            if (bytesRead > 0)
                            {
                                // Translate data bytes to an ASCII string and append
                                clientData.Append(Encoding.ASCII.GetString(bytes, 0, bytesRead));
                                // decrease read timeout to 1 second now that data is 
                                // coming in
                                ns.ReadTimeout = 1000;
                            }
                        }
                        catch (IOException ioe)
                        {
                            // read timed out, all data has been retrieved
                            Trace.WriteLine("Read timed out: {0}", ioe.ToString());
                            bytesRead = 0;
                        }
                    }
                    while (bytesRead > 0);
                    bytes = Encoding.ASCII.GetBytes("clowns");
                    // Send back a response.
                    ns.Write(bytes, 0, bytes.Length);
                    sendMessage(clientData.ToString());
                }
            }
            finally
            {
                // stop talking to client
                if (newClient != null)
                    newClient.Close();
            }
        }
    }
    public class TcpMessageReceivedEventArgs : EventArgs
    {
        private string m_message;
        public TcpMessageReceivedEventArgs(string message)
        {
            m_message = message;
        }
        public string Message
        {
            get
            {
                return m_message;
            }
        }
    }
