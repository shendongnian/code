    public delegate void ConnectionEventHandler(Server sender, Connection connection);
    public partial class Server
    {
        protected virtual void OnClientConnected(Connection connection)
        {
            if (ClientConnected != null) ClientConnected(this, connection);
        }
        public event ConnectionEventHandler ClientConnected;
    }
