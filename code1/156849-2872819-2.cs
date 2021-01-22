    var countriesNames =
        from country in countries
        order by country.Name
        let cityNames = country.Cities.OrderBy(c => c.Name).ToArray()
        select new
        {
            Name = country.Name
            Cities = string.Join(" ", cityNames)
        }
    foreach (var country in countriesNames)
    {
        Console.WriteLine(country.Name + " " + country.Cities);
    }
