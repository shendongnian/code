    using (var context = new MyEntities())
    {
        Role role = (from r in context.Roles.Include("Users")
                     where r.RoleName == roleName
                     select r).FirstOrDefault();
        return role.SelectMany(x => x.Users).Select(x => x.UserName).ToArray();
    }
