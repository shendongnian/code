    var xElement = new XElement("Orders",
    new XElement("NewOrders")
    );
    
    for (int i = 0; i < 2; i++)
    {
    	xElement
    	.Elements()
    	.FirstOrDefault(e => e.Name == "NewOrders")
    	.Add(
    		new XElement("Order",
    			new XElement("OrderNumber", "ABC"),
    			new XElement("Amount", 5.55)
    		)
    	);
    }
