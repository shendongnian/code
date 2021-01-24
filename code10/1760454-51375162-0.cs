    builder.Entity<AspNetUserRole>()
        .HasOne(x => x.AspNetUser)
        .WithMany(x => x.AspNetUserRoles)
        .HasForeignKey(x => x.UserId);
    
    builder.Entity<AspNetUserRole>()
        .HasOne(x => x.AspNetRole)
        .WithMany(x => x.AspNetUserRoles)
        .HasForeignKey(x => x.RoleId);
