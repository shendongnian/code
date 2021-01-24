    categories.Add(new Category
    {
        Name = "popular",
        Code = "popular",
        Values = allFilteredCars.SelectMany(c => c.Offerings)
            .GroupBy(o => o)
            .Select(grp => new Value
            {
                Code = grp.Key,
                Name = grp.Key,
                Count = grp.Count()
            }).ToList()
    });
