    System.Data.SqlClient.SqlBulkCopy bc = new System.Data.SqlClient.SqlBulkCopy("...");
    // Begin a loop to process managable-size batches of source data.
    using (System.Data.DataTable dtTarget = new System.Data.DataTable("sqlTable"))
    {
       // Populate dtTarget with the data as it should appear
       // on the SQL Server side.
       // If the mapping is simple, you may be able to use
       // bc.ColumnMappings instead of manually re-mapping.
       bc.DestinationTableName = "sqlTable";
       bc.WriteToServer(dtTarget);
    }
    // End loop.
