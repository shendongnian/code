    var result = dbContext.Groups.SelectMany(
        group => group.Users,
        (group, user) => new
        {
            // Select the Group properties you plan to use
            GroupId = group.GroupId,
            GroupName = group.Name,
            ...
            // Select the User properties you plan to use
            UserId = user.UserId,
            UserName = user.DisplayName,
            ...
        })
        // if desired do some ordering
        .OrderBy(joinedItem => joinedItem.GroupName);
