    IList<Gu> gus = Context.GuSet
      .Include(gu=>gu.User)//make sure the User property is hydrated - this might have been your actual problem?  not 100% sure though
      .Where(gu => gu.Id == id)
      .OrderBy(gu=>gu.User.Name).ToList();
    //first get a list of users.
    var users = TabWebContext.UserSet.Select(o => new UserModel
    {
        Id = o.Id,
        UserName = o.Name
    })
    //fetch into List<UserModel> - note the DB will now get hit HERE
    //with something like "select id, name from users"
    .ToList();
    
    //as users is now a List<T> we can iterate over it and change each entry.
    users.ForEach(u=>u.SomeBoolean=gus.FirstOrDefault(gu=> gu.User.Id == u.Id).SomeBoolean);
