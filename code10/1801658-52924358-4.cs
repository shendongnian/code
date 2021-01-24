    var result = myDbContext.Listings
       .Where(listing => ...)                   // only if you don't want all listings
       .Select(listing => new
       {
            Id = listing.Id,
            Name = list.Name,
            Categories = listing.Categories
                .Where(category => category.Enabled) // keep only the enabled categories
                .Select(category => new
                {
                    Id = category.Id,
                    Name = category.Name,
                    ...
                })
                .ToList(),
           })
        // this will give you also the Listings that have only disabled categories,
        // so listings that have any categories left. If you don't want them:
        .Where(listing => listing.Categories.Any());
