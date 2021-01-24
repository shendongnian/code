    var result = dbContext.Users
        .Where(user => ...)              // only if you don't want all Users
        .Select(user => new
        {
            // Select only the User data you actually plan to use
            Id = user.Id,
            Name = user.Name,
            ...
            Trackings = user.Trackings
                .Where(tracking => tracking.Date >= startDate) // only if you don't want all Trackings
                .Select(tracking => new
                {
                     // again: select only the properties you plan to use
                     Id = tracking.Id,
                     Name = tracking.Name,
                     ...
                     // not needed, you know the value: UserId = tracking.UserId
                })
                .ToList(),
        });
