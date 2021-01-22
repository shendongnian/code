    XElement xml = new XElement("MyMenu",
        //from c in db.Orders
        from c in db.Orders
        orderby c.OrderID
        select new XElement("Item",
            c.OrderID == null ? null : new XAttribute("OrderID", c.OrderID),
            c.ShipName == null ? null : new XAttribute("ShipName", c.ShipName),
            c.OrderDate == null ? null : new XAttribute("OrderDate", c.OrderDate),
            from od in db.Order_Details
            where od.OrderID == c.OrderID
            select new XElement("SubItem", 
                od.OrderID == null ? null : new XAttribute("OrderID", od.OrderID),
                od.ProductID == null ? null : new XAttribute("ProductID", od.ProductID),
                od.Quantity == null ? null : new XAttribute("Quantity", od.Quantity)
            )
        ));
