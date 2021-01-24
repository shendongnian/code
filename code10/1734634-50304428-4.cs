    // consider wrapping in a using as well
    SqlCommand Cmd = new SqlCommand("SELECT NAME FROM sys.TABLES", SourceServerName);
    SourceServerName.Open();
    System.Data.SqlClient.SqlDataReader reader = Cmd.ExecuteReader();
    while(reader.Read())
    {
        // create a new command to truncate the table at the destination
        using(var TruncateCmd = new SqlCommand("TRUNCATE TABLE " + reader["name"], DestinationServerName))
        {
            DestinationServerName.Open();
            TruncateCmd.ExecuteNonQuery();
        }
        // sqlbulkcopy is IDisposable, wrap in a using
        using(var SqlBulkCopy bulkData = new SqlBulkCopy(DestinationServerName))
        {
            // have a new SourceCmd to get a DataReader for the source table
            // create a new connection, just to be sure
            using(var SourceCon = new SqlConnection(SourceServerName.ConnectionString))
            using(var SourceCmd = new SqlCommand("select * FROM " + reader["name"], SourceCon))
            {
                SourceCon.Open(); // this is definitely needed
                DestinationServerName.Open(); // not 100% sure if this is needed
                bulkData.DestinationTableName = reader["name"].ToString();
                // WriterToServer knows how to deal with a DataReader
                bulkData.WriteToServer(SourceCmd.ExecuteReader());
            } 
        }
    }
