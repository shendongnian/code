    select new Listing()
    {
        ID = g.ID,                               
        CategoryID = g.CategoryID,
        Title = g.Title,
        Description = g.Description,
        Price = g.Price,
        Location = g.Location,
        Created = g.Created,
        DistanceInMiles = (distance / 1609.344),
        ListingPictures = g.ListingPictures, //Add this line
        Category = g.Category //and this line
    });
