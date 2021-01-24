    var data = _entities.ItemZonePrices
                      .Where(x => x.ItemCode == itemcode).ToList()
                     .GroupBy(x => x.ItemCode)
                     .Select(s=> new EPItemZonePriceGetDto
                                {
                                    ItemCode = s.Key,
                                    ItemZonePrices = s.Select( x => 
                                                          new EPZonePriceDto()
                                                             {
                                                               Price = x.Price.ToString(),
                                                               ZoneId = x.ZoneId
                                                             })
                                });
