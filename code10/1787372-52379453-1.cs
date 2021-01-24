    var order = new Order 
    {
      OrderNumber = orderVM.OrderNumber,
      // populate order details...
      OrderLines = orderVM.OrderLines.Select(ol => new OrderLine
      {
        // Populate order lines from view model.
      }).ToList(),
    }
    context.Orders.Add(order);
