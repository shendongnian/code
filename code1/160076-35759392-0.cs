    var bulk = new BulkOperation(connection);
    
    // Output Identity
    bulk.ColumnMappings.Add("ProductID", ColumnMappingDirectionType.Output);
    // ... Column Mappings...
    
    bulk.BulkInsert(dt);
