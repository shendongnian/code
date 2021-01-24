    var addedOrder = myDbContext.Orders.Add(new Order()
    {
         Total = calculatedTotal, // or null
         OrderLines = new OrderLines[]
         {
              new OrderLine() {Sku = ...; ...},
              new OrderLine() {Sku = ...; ...},
              new OrderLine() {Sku = ...; ...},
         },
    });
