    var listings = Listings
      .Where(x => x.Category == categoryName)
      .Select(x => new 
      {
        AdGuid = x.AdGuid,
        ListDate = x.ListDate,
        Image1 = x.ListingImage.Image1
      })
      .AsEnumerable() // make call to DB
      .Select(x => new ResultsViewModel
      {
        AdGuid = x.AdGuid,
        ListDate = x.ListDate,
        ListingAge = Logic.App.GetListingAge(x.BirthDate ?? DateTime.Now),
        Image1 = x.Image1
      })
      .ToList();  //Materialize the local query into a real list.
