    public override string[] GetRolesForUser(string username)
    {
        using (var ctx = new MyDataContext()) {
            return ctx.Users.Where(u => u.UserName== username)
                            .SingleOrDefault().Roles
                            .Select(r => r.RoleName).ToArray<string>();
        }
    }
