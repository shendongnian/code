    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString, transaction))
    {
        // SET BatchSize value.
        bulkCopy.BatchSize = 4000;
    
        bulkCopy.DestinationTableName = "TheDestinationTable";
        bulkCopy.WriteToServer(dt);
    }
