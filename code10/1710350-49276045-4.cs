    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.Id)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.PasswordHash)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.SecurityStamp)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<ApplicationUser>()
        .Property(b => b.PhoneNumber)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<IdentityRole>()
        .Property(b => b.Id)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserRole>()
        .Property(b => b.UserId)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserRole>()
        .Property(b => b.RoleId)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserLogin>()
        .Property(b => b.UserId)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserLogin>()
        .Property(b => b.LoginProvider)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserLogin>()
        .Property(b => b.ProviderKey)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserClaim>()
        .Property(b => b.UserId)
        .HasColumnType("nvarchar")
        .HasMaxLength(128);
    modelBuilder.Entity<IdentityUserClaim>()
        .Property(b => b.ClaimType)
        .HasColumnType("nvarchar(MAX)");
    modelBuilder.Entity<IdentityUserClaim>()
        .Property(b => b.ClaimValue)
        .HasColumnType("nvarchar(MAX)");
