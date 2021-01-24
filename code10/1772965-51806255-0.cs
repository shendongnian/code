    modelBuilder.Entity<AspNetUserRole>()
        .HasOne(aur => aur.User)
        .WithMany(aur => aur.AspNetUserRoles)
        .HasForeignKey(aur => aur.UserId);
    modelBuilder.Entity<AspNetUserRole>()
        .HasOne(aur => aur.Role)
        .WithMany(aur => aur.AspNetUserRoles)
        .HasForeignKey(aur => aur.RoleId);
