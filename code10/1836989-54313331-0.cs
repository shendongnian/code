    var result = items1.Union(items2).GroupBy(x => x.Id)
                     .Select(x => new Item
                     {
                         Id = x.Key,
                         Price = x.Min(i => i.Price)
                     });
