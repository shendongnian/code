    var finalEntries = new List<object>();
    
    // not sure about your type
    var groupedItemList = _context.MyDbTableEntity
                          .Select(k => new { name = k.name.ToString(), data = k.info.ToString() })
                          .GroupBy(k => k.name)
                          .ToList();
    
    finalEntries.AddRange(groupedItemList);
