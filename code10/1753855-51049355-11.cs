    private static List<Order> orders;
    static OrderRepository()
    {
        orders.Add(new Order
        {
            CustomerId = "1",
            OrderId = "1",
            // other properties
        });
        orders.Add(new Order
        {
            CustomerId = "1",
            OrderId = "2",
            // other properties
        });
        // ...etc
    }
