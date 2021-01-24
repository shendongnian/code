	modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.PasswordHash)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.SecurityStamp)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<ApplicationUserClaim>()
        .Property(b => b.ClaimType)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<ApplicationUserClaim>()
        .Property(b => b.ClaimValue)
        .HasColumnType("nvarchar(MAX)");
