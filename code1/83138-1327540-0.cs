    using (SqlBulkCopy copy = new SqlBulkCopy(MySQLExpConn))
    {
        copy.ColumnMappings.Add(0, 0);
        copy.ColumnMappings.Add(1, 1);
        copy.ColumnMappings.Add(2, 2);
        copy.ColumnMappings.Add(3, 3);
        copy.ColumnMappings.Add(4, 4);
        copy.ColumnMappings.Add(5, 5);
        copy.ColumnMappings.Add(6, 6);
        copy.DestinationTableName = ds.Tables[i].TableName;
        copy.WriteToServer(ds.Tables[i]);
     }
