    using (CsvReader reader = new CsvReader(path))
    using (SqlBulkCopy bcp = new SqlBulkCopy(CONNECTION_STRING))
    {
        bcp.DestinationTableName = "SomeTable";
        bcp.WriteToServer(reader);
    }
