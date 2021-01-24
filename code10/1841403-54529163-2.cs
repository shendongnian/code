    private void SomeMethod()
    {
        db.Users.AsQueryable()
        .Where(u => u.Id = userResolver.LoggedUserId() &&
             u.Packages.Where(p => IsShippedOrInProgress())
            .Sum(p => p.Price) > u.MaxCredit)
        .ToList()
    }
