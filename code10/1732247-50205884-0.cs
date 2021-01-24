    var finalEntries = new List<MyDbTableEntity>();
    
    var groupedItemList = _context.MyDbTableEntity
                          .Select(k => new MyDbTableEntity { Name = k.name.ToString(), Data = k.info.ToString() })
                          .GroupBy(k => k.Name)
                          .ToList();
    
    finalEntries.AddRange(groupedItemList);
