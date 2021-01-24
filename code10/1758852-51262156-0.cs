                                     .Select(g => new 
                                      {
                                          Catagorie = g.Key.Catagorie.Name,
                                          ItemName = g.Key.ItemName,
                                          ItemQty = g.Sum(s => s.ItemQty),
                                          Location = g.First().Location.Name
    
                                      })
