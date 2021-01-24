    var query =  CareItemFactory.Instance.GetByCareProgram(facilityId, careProgramId);
    var nonDisabledQuery = query.Where(x => !x.IsDisabled && !x.CareItemCategory.IsDisabled);
    var result = nonDisabledQuery.Select(i => new CareItemView
    {
        ID = i.ID,
        Category = i.CareItemCategory.Name,
        Name = i.Name
    }).ToList();
    if (includeDisabled)
    {
        var disabledList = query.Where(x => x.IsDisabled || x.CareItemCategory.IsDisabled).Select(i => new CareItemView
        {
            ID = i.ID,
            Category = $"Disabled Care Items",
            Name = i.Name
        }).ToList();
        result.AddRange(disabledList);
    }
    
    return result;
