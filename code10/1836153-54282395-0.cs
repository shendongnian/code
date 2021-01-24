    List<Listing> items1 = items.Select(g => select new Listing()
                                 {
                                     ID = g.ID,                               
                                     CategoryID = g.CategoryID,
                                     Title = g.Title,
                                     Description = g.Description,
                                     Price = g.Price,
                                     Location = g.Location,
                                     Created = g.Created,
                                     DistanceInMiles = (g.Geolocation.Distance(point) / 1609.344),
                                 });
