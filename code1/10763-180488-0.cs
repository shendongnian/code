    // C#
    private List<User> GetUsersFromRoles(uint[] UserRoles)
    {
       var users = dc.Users;
       foreach(uint role in UserRoles)
       {
          users = users.Where(u => (u.UserRolesBitmask & role) == role);
       }
       return users.ToList();
    }
