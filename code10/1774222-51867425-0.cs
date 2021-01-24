    IQueryable<Request> requests = GetList();
    List<OrderViewModel> orderVMs = requests.Select(x => new OrderViewModel
    {
      OrderId = x.Order.OrderId,
      RequestId = x.RequestId,
      CustomerName = x.Customer.Name,
      OrderNumber = x.Order.OrderNumber,
      // ...
    }).ToList();
