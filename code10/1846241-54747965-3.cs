    var result = dbContext.TestParents.GroupJoin(dbContext.TestChildren,
        parent => parent.Id,                // from each parent take the Id
        child => child.ParentId,            // from each child take the ParentId
        // resultSelector:
        (parent, children) => new
        {
            // Parent Properties:
            Id = parent.Id,
            ...
            // GroupJoin the collection of child properties with the TestTags:
            children.GroupJoin(dbContext.TestTags,
            child => child.TestTagId,          // from each TestChild take the TestTagId
            tag => tag.Id,                     // from each TestTag take the Id
            (child, tagsOfThisChild) => new
            {
                // desired Child properties
                ...
                TestTags = tagsOfThisChild.Select(tag => new
                {
                     Id = tag.Id,
                     ...
                })
                .ToList(),
            })
            .ToList(),
        });
