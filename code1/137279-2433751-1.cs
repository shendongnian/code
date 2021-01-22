    void SubmitOrders()
    {
        var orders = GetOrders()
        foreach (Order o in orders)
        {
            SubmitOrder(o);
        }
    }
    void SubmitOrder(Order order)
    {
        foreach (OrderDetail d in order.Details)
        {
            // Blah...
        }
    }
