    // consider Order class that data structure you receive from your ERP system
    List<Order> orders = YourERP.GetOrders();
    XmlDocument xml = new XmlDocument();
    xml.AppendChild(xml.CreateElement("Orders"));
    foreach (Order order in orders)
    {
        XmlElement item = xml.CreateElement("Order");
        item.SetAttribute("OrderNumber", order.OrderNumber);
        item.AppendChild(xml.CreateElement("ItemNumber")).Value = order.ItemNumber;
        item.AppendChild(xml.CreateElement("QTY"       )).Value = order.Quantity;
        item.AppendChild(xml.CreateElement("WareHouse" )).Value = order.WareHouse;
        xml.DocumentElement.AppendChild(item);
    }
