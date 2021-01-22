    // Load the reports in bulk
    SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString);
    // Map the columns
    foreach(DataColumn col in dataTable.Columns)
       bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
    bulkCopy.DestinationTableName = "SQLTempTable";
    bulkCopy.WriteToServer(dataTable);
