                  .Select(igg => new MasterEntity {
                      Item = new ItemEntity {
                          ItemDate = igg.First().Key.ItemDate,
                          Duration = igg.Count(),
                          Field1 = g.Key.Field1,
                          Filed2 = g.Key.Filed2,
                          Field3 = g.Key.Field3
                      },
                      ItemList = igg.First().First().Select(di => di.i.ItemId).ToList(),
                      GroupList = igg.First().Key.Groups.ToList()
                  })
    )
    .ToList();
