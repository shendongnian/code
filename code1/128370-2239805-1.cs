    // IQueryable<User> (query setup)
    dataContext.Users
    // from IEnumerable<User> to List<User> (pull from Sql Server into memory)
    .ToList()
    // via enumerating list of User entities (now in memory)
    .ForEach
    (
       // define entity in this iteration
       user =>
          // define operation on entity
          user.ShowData = false;
    );
