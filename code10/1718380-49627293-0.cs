    protected override void OnModelCreating(DbModelBuilder builder)
    {
        // Add this line
        base.OnModelCreating(builder);
   
        builder.Conventions.Remove<PluralizingTableNameConvention>();
        builder.Entity<IdentityUserClaim>().ToTable("UserClaim").HasKey<Int32>(r => r.Id);
        builder.Entity<IdentityUserLogin>().ToTable("UserLogin").HasKey<string>(l => l.UserId);
        builder.Entity<IdentityRole>().ToTable("Role").HasKey<string>(r => r.Id);
        builder.Entity<User>().ToTable("User").HasKey(r => new{ r.IDNumber, r.UserName});
        builder.Entity<IdentityUser>().ToTable("User").HasKey<string>(r => r.UserName);
        builder.Entity<IdentityUserRole>().ToTable("UserRole").HasKey(r => new { r.RoleId, r.UserId });
    }
