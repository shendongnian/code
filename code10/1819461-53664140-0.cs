    var Linq6 = (from p in northwindEntities.Products
                 group p by p.CategoryID into grp
                 join c in northwindEntities.Categories on grp.Key equals c.CategoryID
                 select new
                 {
                     Key = c.CategoryID,
                     Products = grp.ToList()
                 }).ToList();
    
    
    foreach (var item in Linq6)
    {
        Console.WriteLine(item.Key);
        foreach (var i in item.Products)
        {
            Console.WriteLine($" {i.ProductName}");
        }
    }
