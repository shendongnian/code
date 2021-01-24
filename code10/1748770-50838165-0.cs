    var worldPopulation = new Dictionary<string, Dictionary<string, long>>()
    {
        {"US", new Dictionary<string, long>()
        {
            { "New York", 4 },
            { "Miami", 5 }
        }},
        {"Spain", new Dictionary<string, long>()
        {
            { "Madrid", 3 },
            { "Barcelona", 1 },
        }},
        {"France", new Dictionary<string, long>()
        {
            { "Paris", 7 },
        }},
    };
    worldPopulation = worldPopulation.OrderByDescending(x => x.Value.Values.Sum()).
        ToDictionary(x => x.Key, 
        x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value));
    foreach (var country in worldPopulation)
    {
        Console.WriteLine(country.Key);
        foreach (var city in country.Value)
            Console.WriteLine("   " + city.Key + " - " + city.Value);
    }
