    var result = customers.GroupJoin(orders, // GroupJoin the customers with orders
        customer => customer.Name,           // from every customer take the Name
        order => order.CustomerName,         // from every order take the CustomerName
        (customer, orders) => new            // for every customer with all his matching orders
        {                                    // make one new object
            Id = customer.Id,                  // take Id and Name from the matching Customer
            Name = customer.Name,
            // TODO Decide what to do if there are several orders for customer with this name
            // Keep all orders? Or keep the oldest one, the newest one?
            // the unpaid ones?
            AllOrders = orders.ToList(),
            OldestOrder = orders.Orderby(order => order.Date).FirstOrDefault(),
            NewestOrder = orders.OrderByDescending(order => order.Date).FirstOrDefault(),
            UnpaidOrders = orders.Where(order => order.Status == Status.Unpaid).ToList(),
        })
        .ToList();
