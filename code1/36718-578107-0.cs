        SqlBulkCopy bulkCopy = 
            new SqlBulkCopy
            (
            connection, 
            SqlBulkCopyOptions.TableLock | 
            SqlBulkCopyOptions.FireTriggers | 
            SqlBulkCopyOptions.UseInternalTransaction,
            null
            );
        // set the destination table name
        bulkCopy.DestinationTableName = this.tableName;
        // write the data in the "dataTable"
        bulkCopy.WriteToServer(dataTable);
