    int total = customer.Count()
    
    var counts = customers.GroupBy( c => c.Status )
      .Select( g => new
      {
        Status = g.Key,
        TheRatio = (g.Count() * 100) / total;
      })
