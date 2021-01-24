    var viewModelList = dbContext.Customers
                    .Include(a => a.Orders)
                    .ToCustomersModel()
                    .ToList();
    
    
    public static IQueryable<CustomersModel> ToCustomersModel(this IQueryable<Customer> query)
    {
        return query.Select(customer => new CustomersModel
                            {
                                Id = customer.Id,
                                Name = customer.Name,
                                Orders = customer.Orders.ToList().Select(customer => new OrdersModel
                                                               {
                                                                   Id = order.Id,
                                                                   ProductName = order.ProductName
                                                               }).ToList()
                            });
    }
