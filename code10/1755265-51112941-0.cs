    public IEnumerable<User> Handle(List<Guid> musthaveRoles)
    {
        var queryResult = Users.Where(
            u => u.Roles.Select(r => r.RoleId).OrderBy(id => id)
                .SequenceEqual(musthaveRoles.OrderBy(id => id)));
        return queryResult;
    }
