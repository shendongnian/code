    var products = new[] {
        new {SaleDate = DateTime.Parse("10/22/09"), Product = "Soap", Quantity = 10},
        new {SaleDate = DateTime.Parse("09/22/09"), Product = "Pills", Quantity = 5},
        new {SaleDate = DateTime.Parse("09/25/09"), Product = "Soap", Quantity = 6},
        new {SaleDate = DateTime.Parse("09/25/09"), Product = "Pills", Quantity = 15}
    };
    var summary = from p in products
                  let k = new { 
                       Month = p.SaleDate.Date.AddDays(-1 *p.SaleDate.Day - 1), 
                       Product = p.Product }
                  group p by k into t
                  select new { Month = t.Key.Month, 
                               Product = t.Key.Product, 
                               Qty = t.Sum(p => p.Quantity) };
    foreach (var item in summary)
        Console.WriteLine(item);
    //{ Month = 10/1/2009 12:00:00 AM, Product = Soap, Qty = 10 }
    //{ Month = 9/1/2009 12:00:00 AM, Product = Pills, Qty = 20 }
    //{ Month = 9/1/2009 12:00:00 AM, Product = Soap, Qty = 6 }
