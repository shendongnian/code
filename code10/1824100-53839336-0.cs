    var duplicates = listAnimals
        .GroupBy(a => (a.Name, a.Gender))
        .Where(g => g.Count() > 1)
        .Select(g => new Animal {
            Name = $"{g.Key.Name} {g.Key.Gender} totals",
            Age = g.Sum(a => a.Age),
            Gender = g.Key.Gender
        });
    listAnimals = listAnimals
        .Concat(duplicates)
        .OrderBy(a => a.Name)
        .ToList();
