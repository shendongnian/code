    public void BatchBulkCopy(DataTable dataTable, string DestinationTbl, int batchSize, List<string> columnMapping)
    {
        // Get the DataTable 
        DataTable dtInsertRows = dataTable;
        using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity))
        {
            sbc.DestinationTableName = DestinationTbl;
    
            // Number of records to be processed in one go
            sbc.BatchSize = batchSize;
    
            // Add your column mappings here
            foreach(var mapping in columnMapping)
            {
                var split = mapping.Split(new[] { ',' });
                sbc.ColumnMappings.Add(split.First(), split.Last());
            }
    
            // Finally write to server
            sbc.WriteToServer(dtInsertRows);
        }
    }
