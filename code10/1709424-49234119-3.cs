    public class DBConnection
    { 
        public OracleCommand oracleCommand;
        public string cmd = "";
        public void makeConnection()
        {
            //Opening connection
            string connectionString = "XXXX";
            OracleConnection con = new OracleConnection();
            con.ConnectionString = connectionString;
            con.Open();
            this.oracleCommand = con.CreateCommand(); // here
            cmd = oracleCommand.CommandText;
            //Clossing resources
            con.Close();
            oracleCommand.Dispose();
        }
