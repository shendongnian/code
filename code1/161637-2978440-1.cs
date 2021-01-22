    #region BatchBulkCopy
    public void BatchBulkCopy(DataTable dataTable, string DestinationTbl, int batchSize)
    {
        // Get the DataTable 
        DataTable dtInsertRows = dataTable;
    
        using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
        {
            sbc.DestinationTableName = DestinationTbl;
    
            // Number of records to be processed in one go
            sbc.BatchSize = batchSize;
    
            // Add your column mappings here
            sbc.ColumnMappings.Add("field1","field3");
            sbc.ColumnMappings.Add("foo","bar");
    
            // Finally write to server
            sbc.WriteToServer(dtInsertRows);
            sbc.Close();
        }
    
    }
    #endregion
