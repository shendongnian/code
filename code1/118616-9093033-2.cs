    static void Main(string[] args)
    {
        using (SqlConnection connection = new SqlConnection(@"someconnectionstring"))
        {
            connection.Open();
            using(SqlCommand command = new SqlCommand("test", connection))
            {
                connection.InfoMessage += new SqlInfoMessageEventHandler(connection_InfoMessage);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt); // Do something with DataTable
                }
            }
        }
    }
    
    static void connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
    {
        // e contains info message etc
    }
