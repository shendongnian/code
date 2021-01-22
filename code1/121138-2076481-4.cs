    using XE = System.Xml.Linq.XElement;
    using XA = System.Xml.Linq.XAttribute;
    ...
    var xml = new XE("Orders",
        new XE("Order",
            new XA("OrderNumber", 12345),
            new XA("ItemNumber", "01234567"),
            new XA("QTY", 10),
            new XA("Warehouse", "PA019")
        )
    );
