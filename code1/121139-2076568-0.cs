    var xml = new XElement("Orders",
        orders.Select(order =>
            new XElement("Order",
                new XAttribute("OrderNumber", order.OrderNumber),
                new XElement("ItemNumber", order.ItemNumber),
                new XElement("QTY", order.Quantity),
                new XElement("Warehouse", order.Warehouse)
            ));
    );
