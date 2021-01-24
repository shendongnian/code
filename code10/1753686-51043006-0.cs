    var aUsers = new List<UserA>();
    var bUsers = new List<UserB>();
    // Initialize aUsers and bUsers here
    var aUsersAsCUsers = aUsers.Select(a => new UserC{
      Upn = a.Upn, 
      Firstname = a.Firstname, 
      Lastname = a.Lastname,
      Id = a.Id
    });
    
    var bUsersAsCUsers = bUsers.Select(b => new UserC{
      Upn = b.Upn, 
      Firstname = b.Firstname, 
      Lastname = b.Lastname,
      MemberOf = b.MemberOf,
      SamAccountName = b.SamAccountName
    });
    var cUsers = aUsersAsCUsers.Concat(bUsersAsCUsers)
      .GroupBy(u => u.Upn)
      .Select(c => new UserC() 
      { 
        Upn = c.Upn, 
        Firstname = c.Firstname, 
        Lastname = c.Lastname,
        Id = c.Id,
        MemberOf = c.MemberOf,
        SamAccountName = c.SamAccountName
    });
