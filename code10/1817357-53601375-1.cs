        public static class Connection
    {
        private const string ConnectionString = "Data Source=cristini.dyndns.org,1440;Network Library=DBMSSOCN;Initial Catalog=Workbook2019;User ID=CristiniLogin;Password=Cris369";
        public static System.Data.SqlClient.SqlConnection Conn { get; private set; } = null;
        public static void Create() { Conn = new System.Data.SqlClient.SqlConnection(ConnectionString); }
        public static void Open()
        {
            try { Conn.Open(); }
            catch { System.Windows.MessageBox.Show("Can't connect to the server, please check if you have an internet connection."); }
        }
        public static void Close() { Conn.Close(); }
    }
