    // to select the cities
    var largeCities = dbContext.Countries
                               .Include(t => t.Cities)
                               .Where(c=> c.continent == "asia" 
                                      && c.Cities.Population > 500000)
                               .Select(c => c.Cities).ToList();
    // EDIT
    // to select the countries that have these cities
    var countries = dbContext.Countries
                               .Include(t => t.Cities)
                               .Where(c=> c.continent == "asia" 
                                      && c.Cities.Population > 500000)
                               .ToList();  // remove .Select(c => C.Cities) if you want the countries
