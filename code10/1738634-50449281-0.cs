    var filteredList = a.GroupBy(e => e.Id).Select(g =>
    {
         var item = g.First();
         return new Item
         {
             Id = item.Id,
             Name = item.Name,
             Code = item.Code,
             Price = g.Sum(e => e.Price)
         };
    }).ToList();
