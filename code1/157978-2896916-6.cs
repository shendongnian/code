        var dict = Assembly.GetExecutingAssembly()
            .GetTypes()
            .SelectMany(/* ... */)
            .GroupBy(x => x.Key, x => x.Value)
            .ToDictionary(g => g.Key, g => g.ToList());
