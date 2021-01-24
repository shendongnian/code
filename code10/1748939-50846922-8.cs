    using (var myContext = new MyDbContext())
    {
      var orders = myContext.Orders
        .Where(x => x.OrderDate >= startDate && x.OrderDate < endDate)
        .Select(x => new OrderLineViewModel 
        {
          OrderId = x.OrderId,
          OrderNumber = x.OrderNumber,
          OrderAmount = x.OrderAmount,
          CustomerName = x.Customer.Name
        }).ToList();
      return orders;
    }
