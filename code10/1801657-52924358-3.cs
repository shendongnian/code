    var result = myDbcontext.Listings
        .Select(listing => new
        {   // select only the properties you plan to use
            Id = listing.Id,
            Name = listing.Name,
            ...
 
            Categories = listing.Categories
                // you don't want all categories, you only want categories with id 1 or 3
                .Where(category => category.Id == 1 || category.Id == 3)
                .Select(category => new
                {
                     // again select only the properties you plan to use
                     Id = category.Id,
                     Enabled = category.Enabled,
                     ...
                })
                .ToList(),
        })
        // this will also give you the Listings without such Categories,
        // you only want Listings that have any Categories left
        .Where(listing => listing.Categories.Any());
