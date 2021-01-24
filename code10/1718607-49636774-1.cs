    using (var cn = new SqlConnection(myConnectionString))
    {
        var p = new {
            CustomerId = myCustomerId,
            ItemId = myItemId,
            Quantity = myQuantity
        }
 
        cn.Execute("Insert_Order_With_Details", p, commandType: CommandType.StoredProcedure);
    }
