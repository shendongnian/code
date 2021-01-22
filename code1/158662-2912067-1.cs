    public IList<OrderDTO> GetOrders()
    {
        return Session.Linq<Order>()
                        .Select(o => new OrderDTO {
                                            Id = o.Id
                                            CustomerId = o.Customer.Id
                                            CustomerName = o.Customer.Name
                                            ...
                        }).ToList();
    }
