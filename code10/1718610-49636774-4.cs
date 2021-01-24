    using (var cn = new SqlConnection(myConnectionString))
    {
        var p = new DynampicParametersTvp(new {
            CustomerId = myCustomerId
        });
        p.AddItemsTable(items);
 
        cn.Execute("Insert_Order_With_Details", p, commandType: CommandType.StoredProcedure);
    }
