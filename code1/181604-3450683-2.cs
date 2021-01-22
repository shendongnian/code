    DataTable orders = ds.Tables["SalesOrderHeader"];
    
    var query =
        from order in orders.AsEnumerable()
        where order.Field<bool>("OnlineOrderFlag") == true
        select new
        {
            SalesOrderID = order.Field<int>("SalesOrderID"),
            OrderDate = order.Field<DateTime>("OrderDate"),
            SalesOrderNumber = order.Field<string>("SalesOrderNumber")
        };
    
    foreach (var onlineOrder in query)
    {
        Console.WriteLine("Order ID: {0} Order date: {1:d} Order number: {2}",
            onlineOrder.SalesOrderID,
            onlineOrder.OrderDate,
            onlineOrder.SalesOrderNumber);
    }
