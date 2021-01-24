    var result = dbContext.TestParents
        .Where(parent => ...)             // if you don't want all testParents
        .Select(parent => new
        {
            // select only the properties you plan to use
            Id = parent.Id,
            Name = parent.Name,
            Children = parent.TestChildren
                .Where(child => child.TestTag.Name = "My Test Tag Name")
                .Select(child => new
                {
                    Name = child.TestTag.Name,
                    ...
                })
                .ToList(),
        });
