    public class DBConnection
    { 
        public OracleConnection { get; private set; }
        public string cmd = "";
        public void makeConnection()
        {
            //Opening connection
            string connectionString = "XXXX";
            this.Connection = new OracleConnection();
            this.Connection.ConnectionString = connectionString;
            con.Open();
        }
