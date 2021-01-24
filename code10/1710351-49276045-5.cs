	modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.PasswordHash)
        .HasColumnType("nvarchar(MAX)")
        .HasMaxLength(null);
    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.SecurityStamp)
        .HasColumnType("nvarchar(MAX)")
        .HasMaxLength(null);
    modelBuilder.Entity<ApplicationUserClaim>()
        .Property(b => b.ClaimType)
        .HasColumnType("nvarchar(MAX)")
        .HasMaxLength(null);
    modelBuilder.Entity<ApplicationUserClaim>()
        .Property(b => b.ClaimValue)
        .HasColumnType("nvarchar(MAX)")
        .HasMaxLength(null);
