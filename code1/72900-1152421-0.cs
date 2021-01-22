    IDataReader dr = batch.GetDataReader();
    using (SqlTransaction tx = _connection.BeginTransaction())
    {
        try
        {
            using (SqlBulkCopy sqlBulkCopy =
                new SqlBulkCopy(_connection, SqlBulkCopyOptions.Default, tx))
            {
                sqlBulkCopy.DestinationTableName = TableName;
                SetColumnMappings(sqlBulkCopy.ColumnMappings);
                sqlBulkCopy.WriteToServer(dr);
                tx.Commit();
            }
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
