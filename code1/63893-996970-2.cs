    private static ConnectionString { get { // read from config file once.... return ""; } }
    private SqlConnection getConnection()
    {
        SqlConnection result = new SqlConnection(ConnectionString);
        result.Open();  // I like to open it in advance, but that's less common
        return result;  // you'll want some error handling code in here as well
    }
