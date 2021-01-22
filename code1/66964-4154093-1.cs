    public delegate void ConnectionEventHandler(object sender, ConnectionEventArgs e);
    public class ConnectionEventArgs : EventArgs
    {
        public Connection Connection { get; private set; }
        public ConnectionEventArgs(Connection connection)
        {
            this.Connection = connection;
        }
    }
    public partial class Server
    {
        protected virtual void OnClientConnected(Connection connection)
        {
            if (ClientConnected != null) ClientConnected(this, new ConnectionEventArgs(connection));
        }
        public event ConnectionEventHandler ClientConnected;
    }
