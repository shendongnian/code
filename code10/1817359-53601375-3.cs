        public static class Connection
    {
        private const string ConnectionString = "YOUR CONNECTION";
        public static System.Data.SqlClient.SqlConnection Conn { get; private set; } = null;
        public static void Create() { Conn = new System.Data.SqlClient.SqlConnection(ConnectionString); }
        public static void Open()
        {
            try { Conn.Open(); }
            catch { System.Windows.MessageBox.Show("Can't connect to the server, please check if you have an internet connection."); }
        }
        public static void Close() { Conn.Close(); }
    }
