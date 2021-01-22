    private string singleUserCmd = "alter database db-name set SINGLE_USER";
    private string multiUserCmd = "alter database db-name  set MULTI_USER";
    private SqlConnection SetSingleUser(bool singleUser, SqlConnectionStringBuilder csb)
    {
        string v;
        if (singleUser)
        {
            v = singleUserCmd.Replace("db-name", csb.InitialCatalog);
        }
        else
        {
            v = multiUserCmd.Replace("db-name", csb.InitialCatalog);
        }
        SqlConnection connection = new SqlConnection(csb.ToString());
        SqlCommand cmd = new SqlCommand(v, connection);
     
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
        return connection;
    }
