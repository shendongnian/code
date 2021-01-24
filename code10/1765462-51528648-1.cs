    var query =  CareItemFactory.Instance.GetByCareProgram(facilityId, careProgramId);
    var resultQuery = query.Where(x => !x.IsDisabled && !x.CareItemCategory.IsDisabled)
        .Select(i => new CareItemView
        {
            ID = i.ID,
            Category = i.CareItemCategory.Name,
            Name = i.Name
        });
    if (includeDisabled)
    {
        var resultQuery = resultQuery.Union(query.Where(x => x.IsDisabled || x.CareItemCategory.IsDisabled)
        .Select(i => new CareItemView
        {
            ID = i.ID,
            Category = $"Disabled Care Items",
            Name = i.Name
        }));
    }
    
    return resultQuery.ToList();
