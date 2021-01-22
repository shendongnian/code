    var orders = from amznorders in customer.Root.Elements("Order")
                 from amznfulfill in amznorders.Elements("Fulfillment")
                 from amznitems in amznfulfill.Elements("Item")
                 let amznitemprcs = amznitems.Elements("ItemPrice").Elements("Component").Select(element => new {
                     Type = element.Element("Type").Value,
                     Amount = element.Element("Amount").Value
                 })
                 select new
                 {
                     OrderNumber = amznorders.Element("AmazonOrderID").Value,
                     ItemNumber = amznitems.Element("AmazonOrderItemCode").Value,
                     Qty = amznitems.Element("Quantity").Value,
                     PriceAmount = amznitemprcs.Where(x => x.Type == "Principal").Select(x => x.Amount).FirstOrDefault() ?? string.Empty,
                     TaxAmount = amznitemprcs.Where(x => x.Type == "Tax").Select(x => x.Amount).FirstOrDefault() ?? string.Empty,
                 };
