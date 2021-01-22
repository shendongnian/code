    Northwind.CustomerCollection customersByCategory = new Select()
        .From(Northwind.Customer.Schema)
        .InnerJoin(Northwind.Order.Schema)
        .InnerJoin(Northwind.OrderDetail.OrderIDColumn, Northwind.Order.OrderIDColumn)
        .InnerJoin(Northwind.Product.ProductIDColumn, Northwind.OrderDetail.ProductIDColumn)
        .Where("CategoryID").IsEqualTo(5)
        .ExecuteAsCollection<Northwind.CustomerCollection>();
