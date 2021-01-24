    var subGroups = subGroupCollection.Select(sg => new SubGroupViewModel
    {
        Id = sg.Id,
        Name = sg.Name,
        MainGroupId = sg.MainGroupId,
        GroupId = sg.GroupId,
        IsActive = sg.IsActive,
        Discount = sg.Discount,
        DiscountType = sg.DiscountType
    });
    
    var groups = groupCollection.Select(g => new GroupViewModel 
    {
    	Id = g.Id,
        MainGroupId = g.MainGroupId,
        Name = g.Name,
        IsActive = g.IsActive,
        SubGroups = subGroups.Where(sg => sg.GroupId == g.Id).ToList() 
    });
    
    var mainGroups = mainGroupCollection.Select(mg => new MainGroupViewModel
    {
    	Id = mg.Id,
        Name = mg.Name,
        IsActive = mg.IsActive,
        // .Any() or .All() here?
        Groups = groups.Where(g => g.SubGroups.Any(sg => sg.MainGroupId == mg.Id))
    });
