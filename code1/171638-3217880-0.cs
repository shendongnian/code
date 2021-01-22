    Expression<Func<Customer, CustomerWithRecentOrders>>
      GetCustomerWithRecentOrdersSelector()
    {
      return c => new CustomerWithRecentOrders()
      {
        Customer = c,
        RecentOrders = c.Orders.Where(o => o.IsRecent)
      };
    }
