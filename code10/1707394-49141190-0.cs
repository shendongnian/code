    var table = new DataTable(); //your table here
    var orders = from row in table.Rows.Cast<DataRow>()
                 let item = new
                 {
                     OrderID = row[0],
                     Account = row[1],
                     ItemID = row[999],
                     Price = row[998],
                 }
                 group item by new { item.OrderID, item.Account };
    var xml = new XElement("orders",
        from order in orders
        select new XElement("order",
            new XAttribute("id", order.Key.OrderID),
            new XAttribute("account", order.Key.Account),
            new XElement("items",
                from item in order
                select new XElement("item",
                    new XAttribute("id", item.ItemID),
                    new XAttribute("price", item.Price)
                )
            )
        )
    );
