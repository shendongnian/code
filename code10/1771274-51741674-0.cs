    class User
    {
        public int Id {get; set;}
 
        // every user has zero or more Permissions (many-to-many)
        public virtual ICollection<Permission> Permissions {get; set;}
        ...
    }
    class Permission
    {
        public int Id {get; set;}
 
        // every Permission is granted to zero or more Users (many-to-many)
        public virtual ICollection<User> Users {get; set;}
        ...
    }
    class MyDbContext : DbContext
    {
         public DbSet<User> Users {get; set;}
         public DbSet<Permission> Permissions {get; set;}
    }
