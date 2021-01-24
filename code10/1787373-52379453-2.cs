    var order = new Order 
    {
      OrderNumber = orderVM.OrderNumber,
      // populate order details from view model...
    }
    context.Orders.Add(order);
    foreach(orderLineVM in orderVM)
    {
      var orderLine = new OrderLine
      {
         OrderId = order.OrderId // This will be 0 until after SaveChanges.
      }
      context.OrderLines.Add(orderLine);
    }
