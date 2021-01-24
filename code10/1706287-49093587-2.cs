        var cmd = dbContext.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[GetAllCustomersAndOrders]";
        
        dbContext.Database.Connection.Open();
        // Run the sproc 
        var reader = cmd.ExecuteReader();
        var Customers= ((IObjectContextAdapter)dbContext)
            .ObjectContext
            .Translate<Customer>(reader, "Customers", MergeOption.AppendOnly);   
        reader.NextResult();
        var Orders = ((IObjectContextAdapter)db)
            .ObjectContext
            .Translate<Order>(reader, "Orders", MergeOption.AppendOnly);
    
