    var groupedList = orderedList
      .GroupBy(c => new {c.CustomerId, c.ProductId})
      .OrderBy(g => g.Key.CustomerId)
      .ThenBy(g => g.Key.ProductId)
      .ToList();
    
    foreach(var group in groupedList)
    {
      List<CustomerProduct> cps = group.ToList();
      //do some work with this customer products
    
      //no need to do inefficient list removal - just move on to next group.
    }
