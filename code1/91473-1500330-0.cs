    var sites = from s in DataContext.Sites
                          .OrderBy(s => s.PrimaryAddress.AddressLine1)
                          .ThenBy(s => s.PrimaryAddress.City)
                          .ThenBy(s => s.PrimaryAddress.State)
                          .ThenBy(s => s.PrimaryAddress.Country)
                select new 
                {
                    s.Id,
                    s.SiteName,
                    s.PrimaryAddress
                };
