    DataTable sourceData=new DataTable();
    using (var sqlBulkCopy = new SqlBulkCopy(_connString))
    {
        sqlBulkCopy .DestinationTableName = "DestinationTableName";
        sqlBulkCopy .WriteToServer(sourceData);
    }
