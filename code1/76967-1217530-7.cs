    //get the input datareader
    IDataReader dr = ///.ExecuteDataReader("select floatCol from A", or whatever
    using (SqlTransaction tx = _connection.BeginTransaction())
    {
        try
        {
            using (SqlBulkCopy sqlBulkCopy =
                new SqlBulkCopy(_connection, SqlBulkCopyOptions.Default, tx))
                {
                    sqlBulkCopy.DestinationTableName = "B";
                    SetColumnMappings(sqlBulkCopy.ColumnMappings);
                    //above method omitted for clarity, easy to figure out
                    //now wrap the input datareader in the decorator
                    var sqrter = new SqrtingDataDecorator(dr);
                    //the following line does the data transfer.
                    sqlBulkCopy.WriteToServer(sqrter);
                    tx.Commit();
                }
        }
        catch
        {
            tx.Rollback();
            throw;
        }
    }
