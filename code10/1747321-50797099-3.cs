    using (var dbContext = new MyDbContext(...))
    {
        // you wanted to have a query like:
        var result dbContext.ApplicationUsers
            .Where(user => user.FirstName = "John"
                        && user.LastName = "Doe");
        // you'll have to add ToExtendedUsers:
        var result = dbContext.ApplicationUsers
            .Where(user => user.FirstName = "John"
                        && user.LastName = "Doe");
            .ToExtendedUsers();
    }
