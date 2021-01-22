    public void WriteOrders<T>(IList<Order<T>> orders)
    {
        foreach (Order<T> order in orders)
            Console.WriteLine(order.Delivery.ToString());
    }
