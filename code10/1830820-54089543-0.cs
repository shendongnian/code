    var joinResult = customers.Join(orders,    // join the tables of customers with orders
        customer => customer.Name,             // from every customer take the Name
        order => order.CustomerName,           // from every order take the CustomerName
        (customer, order) => new Customer      // when they match make a new Customer
        {
            Id = customer.Id,                  // take Id and Name from the matching Customer
            Name = customer.Name,
            OrderId = order.Id,                // take the OrderId from the matching order
        })
        .ToList();
    customers = joinResult;
