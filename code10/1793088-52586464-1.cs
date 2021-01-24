    using (var dbContext = new MyDbContext(...))
    {
        var requestedUsers = dbContext.Users
            .Where(user => ...)                      // only if you don't want all Users
            .Select(user => new
            {    // Select only the properties you plan to use:
                 Id = user.Id,
                 Name = user.Name,
                 ...
                 Profiles = user.Profiles
                     .Where(profile => ...)         // only if you don't want all profiles
                     .Select(profile => new
                     {
                          Name = profile.Name,
                          ...
                     })
                     .ToList(),
            })
