    //You probably want to filter to the countries that have states
    var countriesQuery = context.Countries.AsQueryable();
    var statesQuery = countriesQuery.SelectMany(x => x.States);
    statesQuery.Load();
    var cityQuery = statesQuery.SelectMany(x => x.Cities);
    cityQuery.Load();
    cityQuery.SelectMany(x => x.Cars).Load();
    cityQuery.SelectMany(x => x.Buildings).Load();
    return countriesQuery.ToArray()
