    var orders = new List<OrderIndexViewModel>();
        while (reader.Read())
        {
            var order = new OrderIndexViewModel();
            order.CustomerOrderId = reader.GetInt32(0);
            order.FirstName = reader.GetString(1);
            order.ProductId = reader.GetInt32(2);
            order.Name = reader.GetString(3);
            order.Price = reader.GetDecimal(4);
            orders.Add(order);
        }
        cnn.Close();
        return View(orders);
