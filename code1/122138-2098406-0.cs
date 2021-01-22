    var query = Products.Select(p => new {
                             p.Name,
                             SubProducts = Products.Count(c => c.parent_id == p.id)
                         });
    foreach (var item in query)
    {
        Console.WriteLine("{0} : {1}", item.Name, item.SubProducts);
    }
