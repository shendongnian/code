    private object _locker = new object();
    private string CreateOrder(string userName)
    {
        lock(_locker)
        {
            // Fetch current order
            Order order = FetchOrder(userName);
            if (order.OrderId == 0)
            {
                // Has no order yet, create a new one
                order.OrderNumber = Utility.GenerateOrderNumber();
                order.Save();
            }
            return order;
        }
    }
