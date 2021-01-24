    using (var dbContext = new MyDbContext()
    {
         int userId = ...
         string permissionName = ...
         dbContext.GrantPermission(userId, permissionName);
         dbContext.SaveChanges();
    }
