    void SubmitOrders()
    {
        var orders = GetOrders();
        foreach (Order o in orders)
        {
            foreach (OrderDetail d in o.Details)
            {
                // Blah...
            }
        }
    }
