    IEnumerable<Item> items = db.Items;
    var da = items.GroupBy(x=> new { x.Category, x.ItemName })
                  .Select(g => new {
                    Category = g.Key.Category, 
                    ItemName = g.Key.ItemName,
                    Quantity = g.Sum(s => s.ItemQty),
                    Location = g.First().Location}).ToList();
