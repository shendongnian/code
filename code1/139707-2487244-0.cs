    using (var context = new MyEntities())
    {
        return context.Roles
                      .Where( r => r.RoleName == roleName )
                      .SelectMany( r => r.Users )
                      .Select( u => u.UserName )
                      .ToArray();
    }
