    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUser>().ToTable("SSO_USERS");
        modelBuilder.Entity<IdentityUser>().ToTable("SSO_USERS");
        modelBuilder.Entity<ApplicationRole>().ToTable("SSO_ROLES");
        modelBuilder.Entity<IdentityRole>().ToTable("SSO_ROLES");
        modelBuilder.Entity<IdentityUserLogin>().ToTable("SSO_USER_LOGINS");
        modelBuilder.Entity<IdentityUserRole>().ToTable("SSO_USERS_ROLES");
        modelBuilder.Entity<IdentityUserClaim>().ToTable("SSO_USER_CLAIMS");
    }
