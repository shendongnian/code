    //Give me a list of lite data..
    var viewModels = context.Users
        .Where(x => x.DateOfBirth < startDate)
        .Select(x => new LiteUserViewModel
        {
           UserId = x.UserId,
           Name = x.Name,
           FirstName = x.FirstName
        }).ToList();
    
    // Give me a full user.
    var viewModel = context.Users
        .Where(x => x.UserId = userId)
        .Select(x => new FullUserViewModel
        {
           UserId = x.UserId,
           // ... etc ...
        }).SingleOrDefault();
