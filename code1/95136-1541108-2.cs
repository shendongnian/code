    var products = new[] {
        new {SaleDate = new DateTime(2009,10,22), Product = "Soap", Quantity = 10},
        new {SaleDate = new DateTime(2009,09,22), Product = "Pills", Quantity = 5},
        new {SaleDate = new DateTime(2009,09,25), Product = "Soap", Quantity = 6},
        new {SaleDate = new DateTime(2009,09,25), Product = "Pills", Quantity = 15}
    };
    var summary = from p in products
                  let k = new
                  {
                       //try this if you need a date field 
                       //   p.SaleDate.Date.AddDays(-1 *p.SaleDate.Day - 1)
                      Month = p.SaleDate.ToString("MM/yy"),
                      Product = p.Product
                  }
                  group p by k into t
                  select new
                  {
                      Month = t.Key.Month,
                      Product = t.Key.Product,
                      Qty = t.Sum(p => p.Quantity)
                  };
    foreach (var item in summary)
        Console.WriteLine(item);
    //{ Month = 10/09, Product = Soap, Qty = 10 }
    //{ Month = 09/09, Product = Pills, Qty = 20 }
    //{ Month = 09/09, Product = Soap, Qty = 6 }
