    from result in results
    group result by {result.Id, result.Name, result.Address, result.Phone, result.CustomValues, result.CustomFieldLoaded} into g
    select new{
    g.Key.Id,
    g.Key.Name,
    g.Key.Address,
    g.Key.Phone,
    g.Key.CustomFieldLoaded = new {},
    g.Key.CustomValues = g.CustomValues.Select(c=> g.Key.CustomFieldLoaded[g.Key.CustomValues.IndexOf(c)])
    }
