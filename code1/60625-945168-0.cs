    List<Order<ParcelDelivery>> orders = new List<Order<ParcelDelivery>>();
            orders.Add(new CustomerOrder());
            orders.Add(new CustomerOrder());
            orders.Add(new CustomerOrder());
            orders.Add(new CustomerOrder());
            orders.Add(new CustomerOrder());
            foreach (Order<ParcelDelivery> order in orders)
            {
                order.Delivery.ToString();
            }
