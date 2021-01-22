    class SocketTest
    {
        private Socket m_Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public void Test()
        {
            m_Listener.Bind(new IPEndPoint(IPAddress.Loopback, 8888));
            m_Listener.Listen(16);
            m_Listener.BeginAccept(AcceptCallback, null);
        }
        private void AcceptCallback(IAsyncResult ar)
        {
            Socket s = m_Listener.EndAccept(ar);
            m_Listener.Close();
            /* Use s here. */
        }
    }
