    var usersFromDb = _Context.Users
        .Select(u => new MyUser
            {
                Id = u.ID,
                Name = u.Name,
                Time = u.Time
            }).
        .OrderByDescending(u => u.Time)
        .ToList();
