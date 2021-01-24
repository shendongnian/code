    var duplicateTotals = listAnimals
        .GroupBy(a => (a.Name, a.Gender))
        .Where(g => g.Count() > 1)
        .Select(g => new AnimalTotals {
            Name = g.Key.Name,
            Age = g.Sum(a => a.Age),
            Gender = g.Key.Gender
        });
