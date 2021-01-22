    var res = agencies.SelectMany(a => a.BusinessUnits)
                      .GroupBy(b => b.ID)
                      .Select(b => new { 
                         ID = b.Key, 
                         Clients = b.SelectMany(b2 => b2.Clients)
                                    .GroupBy(c => c.ID)
                                    .Select(c => new Client { 
                                       ID = c.Key, 
                                       AmountSpent = c.Sum(c2 => c2.AmountSpent) 
                                     })
                       })
                       .Select(b => new BusinessUnit {
                          ID = b.ID,
                          AmountSpent = b.Clients.Sum(c => c.AmountSpent),
                          Clients = b.Clients
                       });
