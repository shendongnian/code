    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        // custom code here...
        modelBuilder.Entity<IdentityUser>().ToTable("User", "dbo");
        modelBuilder.Entity<IdentityRole>().ToTable("Role", "dbo");
        modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole", "dbo");
        modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim", "dbo");
        modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin", "dbo");
        modelBuilder.Entity<IdentityUserToken>().ToTable("UserToken", "dbo");
        // other custom code here...
    }
