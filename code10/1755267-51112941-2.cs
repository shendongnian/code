    public IEnumerable<User> Handle(List<Guid> musthaveRoles)
    {
        var queryResult = Users.Where(u => u.Roles.Select(r => r.RoleId)
          .Intersect(musthaveRoles).Count() == musthaveRoles.Count);
        return queryResult;
    }
