    var result = mainGroupCollection.Select(mainGroup => new MainGroupViewModel
    {
        Id = mainGroup.Id,
        Name = mainGroup.Name,
        ...
        // Keep only the Groups of this MainGroup, using foreign key
        Groups = groupCollection
            .Where(group => group.MainGroupId == mainGroup.Id)
            .Select(group => new GroupViewModel
            {
                Id = group.Id,
                Name = group.Name,
                ...
                // Keep only the subGroups of this Group, using foreign key
                SubGroups = subGroupCollection
                    .Where(subGroup => subGroup.GroupId == group.Id)
                    .Select(subGroup => new SubGroupViewModel
                    {
                        Id = group.Id,
                        Name = group.Name,
                        ...
                    })
                    .ToList(),
            })
            .ToList(),
    });
