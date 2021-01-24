    var ko= (from r in items.GroupBy(x => new { x.Catagorie, x.ItemName })
                                  .Select(g => new MyObj()
                                  {
                                      Catagorie = g.Key.Catagorie.Name,
                                      ItemName = g.Key.ItemName,
                                      ItemQty = g.Sum(s => s.ItemQty),
                                      Location = g.First().Location.Name
                                  })
                         select r).ToList();
