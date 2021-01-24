    using(SqlConnection source = new SqlConnection(sourceConnectionstring))
    {
        source.Open();
    
        SqlCommand cmd = new SqlCommand("SELECT * FROM MyTable");
    
        SqlDataReader reader = cmd.ExecuteReader();
    
        using(BulkOperation bulkData = new BulkOperation(destinationConnectionstring))
        {
            bulkData.DestinationTableName = "MyTable";
    		
    		// INSERT only if row doesn't exist in the destination
    		bulkData.InsertIfNotExists = true;
            bulkData.WriteToServer(reader);
        }
    }
