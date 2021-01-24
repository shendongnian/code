    .Select(group => new
    {
        Name = group.Key.FName, 
        Count = group.Count(),
        Age = group.First().Age,
        Sex = group.First().Gender
    });
