    modelBuilder.Entity<ApplicationUser>(b =>
    {
        // Each User can have many UserClaims
        b.HasMany(e => e.Claims)
            .WithOne(e => e.User)
            .HasForeignKey(uc => uc.UserId)
            .IsRequired();
    
        // Each User can have many UserLogins
        b.HasMany(e => e.Logins)
            .WithOne(e => e.User)
            .HasForeignKey(ul => ul.UserId)
            .IsRequired();
    
        // Each User can have many UserTokens
        b.HasMany(e => e.Tokens)
            .WithOne(e => e.User)
            .HasForeignKey(ut => ut.UserId)
            .IsRequired();
    
        // Each User can have many entries in the UserRole join table
        b.HasMany(e => e.UserRoles)
            .WithOne(e => e.User)
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
    });
    
    modelBuilder.Entity<ApplicationRole>(b =>
    {
        // Each Role can have many entries in the UserRole join table
        b.HasMany(e => e.UserRoles)
            .WithOne(e => e.Role)
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
    
        // Each Role can have many associated RoleClaims
        b.HasMany(e => e.RoleClaims)
            .WithOne(e => e.Role)
            .HasForeignKey(rc => rc.RoleId)
            .IsRequired();
    });
    
    modelBuilder.Entity<ApplicationUserLogin>(b =>
    {
        b.HasKey(l => new { l.LoginProvider, l.ProviderKey, l.UserId });
        b.ToTable("AspNetUserLogins");
    });
    
    modelBuilder.Entity<ApplicationUserRole>(b =>
    {
        b.HasKey(r => new { r.UserId, r.RoleId });
        b.ToTable("AspNetUserRoles");
    });
    
    modelBuilder.Entity<ApplicationUserToken>(b =>
    {
        b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        b.ToTable("AspNetUserTokens");
    });
