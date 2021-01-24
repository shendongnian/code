    var cities = context.Countries
    .Where(s => query.Name == s.Name)
    .AsEnumerable()    //  where the magic happens
    .Select(s => new CityDTO
    {
        new CityDTO()
        {
            name = s.name,
            stateName = s.stateName
            population = s.population
        }
    });
