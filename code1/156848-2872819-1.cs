    IEnumerable<Country> countries = GetCountries();
    foreach (var country in countries.OrderBy(c => c.Name))
    {
        Console.Write(country.Name + " ");
        foreach (var city in country.Cities.OrderBy(c => c.Name))
        {
            Console.Write(city.Name + " ");
        }
        Console.WriteLine();
    }
