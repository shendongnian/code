    using (var bulkCopy = new BulkOperation(connection))
    {
        bulkCopy.Transaction = transaction;
        bulkCopy.DestinationTableName = "dbo.A";
    
        bulkCopy.ColumnMappings.Add("Id", ColumnMappingDirectionType.Output);
        bulkCopy.ColumnMappings.Add("Col1");
        bulkCopy.ColumnMappings.Add("Col2");
        bulkCopy.BulkInsert(a);
    
        // Copy identity value in `Id` from table A to `ParentId` in table B
        // ...code...
    }
