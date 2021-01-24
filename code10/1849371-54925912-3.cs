    // GroupJoin the mainGroupCollection with the groupCollection:
    var result = mainGroupCollection.GroupJoin(groupCollection,
        mainGroup = mainGroup.Id,         // from every mainGroup take the primary key
        group => group.MainGroupId,       // from every group take the foreign key
        // ResultSelector: for every mainGroup and its groups make one MainGroupViewModel
        (mainGroup, groupsOfThisMainGroup) => new MainGroupViewModel
        {
            Id = mainGroup.Id,
            Name = mainGroup.Name,
            ...
            // for the Groups: GroupJoin the groups of this main group with the subGroups
            Groups = groupsOfThisMainGroup.GroupJoin(subGroupCollection,
                groupOfThisMainGroup => groupOfThisMainGroup.Id,
                subGroup => subGroup.GroupId,
                // result selector
                (group, subGroupsOfThisGroup) => new GroupViewModel
                {
                    Id = group.Id,
                    Name = group.Name,
                   SubGroups = subGroupsOfThisGroup.Select(subGroup => new SubGroupViewModel
                   {
                        Id = subGroup.Id,
                        Name = subGroup.Name,
                        ...
                   })
                   .ToList(),
            })
            .ToList(),
        });
           
