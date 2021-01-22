    public class Telnet
    {
        private readonly Pool<SocketAsyncEventArgs> m_EventArgsPool;
        private Socket m_ListenSocket;
        /// <summary>
        /// This event fires when a connection has been established.
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> Connected;
        /// <summary>
        /// This event fires when a connection has been shutdown.
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> Disconnected;
        /// <summary>
        /// This event fires when data is received on the socket.
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> DataReceived;
        /// <summary>
        /// This event fires when data is finished sending on the socket.
        /// </summary>
        public event EventHandler<SocketAsyncEventArgs> DataSent;
        /// <summary>
        /// Specifies the port to listen on.
        /// </summary>
        [DefaultValue(23)]
        public int ListenPort { get; set; }
        /// <summary>
        /// Constructor for Telnet class.
        /// </summary>
        public Telnet()
        {           
            m_EventArgsPool = new Pool<SocketAsyncEventArgs>();
            ListenPort = 23;
        }
        /// <summary>
        /// Starts the telnet server listening and accepting data.
        /// </summary>
        public void Start()
        {
            IPEndPoint endpoint = new IPEndPoint(0, ListenPort);
            m_ListenSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            m_ListenSocket.Bind(endpoint);
            m_ListenSocket.Listen(100);
            //
            // Post Accept
            //
            StartAccept(null);
        }
        /// <summary>
        /// Not Yet Implemented. Should shutdown all connections gracefully.
        /// </summary>
        public void Stop()
        {
            //throw (new NotImplementedException());
        }
        //
        // ACCEPT
        //
        /// <summary>
        /// Posts a requests for Accepting a connection. If it is being called from the completion of
        /// an AcceptAsync call, then the AcceptSocket is cleared since it will create a new one for
        /// the new user.
        /// </summary>
        /// <param name="e">null if posted from startup, otherwise a <b>SocketAsyncEventArgs</b> for reuse.</param>
        private void StartAccept(SocketAsyncEventArgs e)
        {
            if (e == null)
            {
                e = m_EventArgsPool.Pop();
                e.Completed += Accept_Completed;
            }
            else
            {
                e.AcceptSocket = null;
            }
            if (m_ListenSocket.AcceptAsync(e) == false)
            {
                Accept_Completed(this, e);
            }
        }
        /// <summary>
        /// Completion callback routine for the AcceptAsync post. This will verify that the Accept occured
        /// and then setup a Receive chain to begin receiving data.
        /// </summary>
        /// <param name="sender">object which posted the AcceptAsync</param>
        /// <param name="e">Information about the Accept call.</param>
        private void Accept_Completed(object sender, SocketAsyncEventArgs e)
        {
            //
            // Socket Options
            //
            e.AcceptSocket.NoDelay = true;
            //
            // Create and setup a new connection object for this user
            //
            Connection connection = new Connection(this, e.AcceptSocket);
            
            //
            // Tell the client that we will be echo'ing data sent
            //
            DisableEcho(connection);
            //
            // Post the first receive
            //
            SocketAsyncEventArgs args = m_EventArgsPool.Pop();
            args.UserToken = connection;
            //
            // Connect Event
            //
            if (Connected != null)
            {
                Connected(this, args);
            }
            args.Completed += Receive_Completed;
            PostReceive(args);
            //
            // Post another accept
            //
            StartAccept(e);
        }
        //
        // RECEIVE
        //    
        /// <summary>
        /// Post an asynchronous receive on the socket.
        /// </summary>
        /// <param name="e">Used to store information about the Receive call.</param>
        private void PostReceive(SocketAsyncEventArgs e)
        {
            Connection connection = e.UserToken as Connection;
            if (connection != null)
            {
                connection.ReceiveBuffer.EnsureCapacity(64);
                e.SetBuffer(connection.ReceiveBuffer.DataBuffer, connection.ReceiveBuffer.Count, connection.ReceiveBuffer.Remaining);
                if (connection.Socket.ReceiveAsync(e) == false)
                {
                    Receive_Completed(this, e);
                }              
            }
        }
        /// <summary>
        /// Receive completion callback. Should verify the connection, and then notify any event listeners
        /// that data has been received. For now it is always expected that the data will be handled by the
        /// listeners and thus the buffer is cleared after every call.
        /// </summary>
        /// <param name="sender">object which posted the ReceiveAsync</param>
        /// <param name="e">Information about the Receive call.</param>
        private void Receive_Completed(object sender, SocketAsyncEventArgs e)
        {
            Connection connection = e.UserToken as Connection;
            if (e.BytesTransferred == 0 || e.SocketError != SocketError.Success || connection == null)
            {
                Disconnect(e);
                return;
            }
           
            connection.ReceiveBuffer.UpdateCount(e.BytesTransferred);
            OnDataReceived(e);           
            PostReceive(e);
        }
        /// <summary>
        /// Handles Event of Data being Received.
        /// </summary>
        /// <param name="e">Information about the received data.</param>
        protected void OnDataReceived(SocketAsyncEventArgs e)
        {
            if (DataReceived != null)
            {                
                DataReceived(this, e);
            }
        }       
        //
        // SEND
        //
        /// <summary>
        /// Overloaded. Sends a string over the telnet socket.
        /// </summary>
        /// <param name="connection">Connection to send data on.</param>
        /// <param name="s">Data to send.</param>
        /// <returns>true if the data was sent successfully.</returns>
        public bool Send(Connection connection, string s)
        {
            if (String.IsNullOrEmpty(s) == false)
            {
                return Send(connection, Encoding.Default.GetBytes(s));
            }
            return false;
        }
        /// <summary>
        /// Overloaded. Sends an array of data to the client.
        /// </summary>
        /// <param name="connection">Connection to send data on.</param>
        /// <param name="data">Data to send.</param>
        /// <returns>true if the data was sent successfully.</returns>
        public bool Send(Connection connection, byte[] data)
        {
            return Send(connection, data, 0, data.Length);
        }
        public bool Send(Connection connection, char c)
        {
            return Send(connection, new byte[] { (byte)c }, 0, 1);
        }
        /// <summary>
        /// Sends an array of data to the client.
        /// </summary>
        /// <param name="connection">Connection to send data on.</param>
        /// <param name="data">Data to send.</param>
        /// <param name="offset">Starting offset of date in the buffer.</param>
        /// <param name="length">Amount of data in bytes to send.</param>
        /// <returns></returns>
        public bool Send(Connection connection, byte[] data, int offset, int length)
        {
            bool status = true;
            if (connection.Socket == null || connection.Socket.Connected == false)
            {
                return false;
            }
            SocketAsyncEventArgs args = m_EventArgsPool.Pop();
            args.UserToken = connection;
            args.Completed += Send_Completed;
            args.SetBuffer(data, offset, length);
            try
            {
                if (connection.Socket.SendAsync(args) == false)
                {
                    Send_Completed(this, args);
                }
            }
            catch (ObjectDisposedException)
            {                
                //
                // return the SocketAsyncEventArgs back to the pool and return as the
                // socket has been shutdown and disposed of
                //
                m_EventArgsPool.Push(args);
                status = false;
            }
            
            return status;
        }    
        /// <summary>
        /// Completion callback for SendAsync.
        /// </summary>
        /// <param name="sender">object which initiated the SendAsync</param>
        /// <param name="e">Information about the SendAsync call.</param>
        private void Send_Completed(object sender, SocketAsyncEventArgs e)
        {
            e.Completed -= Send_Completed;              
            m_EventArgsPool.Push(e);
        }             
        //
        // DISCONNECT
        //
        /// <summary>
        /// Disconnects a socket.
        /// </summary>
        /// <remarks>
        /// It is expected that this disconnect is always posted by a failed receive call. Calling the public
        /// version of this method will cause the next posted receive to fail and this will cleanup properly.
        /// It is not advised to call this method directly.
        /// </remarks>
        /// <param name="e">Information about the socket to be disconnected.</param>
        private void Disconnect(SocketAsyncEventArgs e)
        {
            Connection connection = e.UserToken as Connection;
            if (connection == null)
            {
                throw (new ArgumentNullException("e.UserToken"));
            }
            try
            {
                connection.Socket.Shutdown(SocketShutdown.Both);
            }
            catch
            {
            }
            connection.Socket.Close();
            if (Disconnected != null)
            {
                Disconnected(this, e);
            }
            e.Completed -= Receive_Completed;
            m_EventArgsPool.Push(e);
        }
        /// <summary>
        /// Marks a specific connection for graceful shutdown. The next receive or send to be posted
        /// will fail and close the connection.
        /// </summary>
        /// <param name="connection"></param>
        public void Disconnect(Connection connection)
        {
            try
            {
                connection.Socket.Shutdown(SocketShutdown.Both);
            }
            catch (Exception)
            {
            }            
        }       
    }
