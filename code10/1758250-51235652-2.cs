    public static void SaveNewCustomerOrder(string customerId, string orderId, Order order)
    {
        var newCustomer = new CustomerOrder
        {
            CustomerId = customerId,
            OrderId = orderId
        };
        _CustomerOrder.Add(newCustomer);
        _Orders.Add(order);
    }
