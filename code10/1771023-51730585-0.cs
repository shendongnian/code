    modelBuilder.Entity<User>(builder =>
    {
        builder.Metadata.RemoveIndex(new[] { builder.Property(u => u.NormalizedUserName).Metadata });
        builder.HasIndex(u => new { u.NormalizedUserName, u.TenantId }).HasName("UserNameIndex").IsUnique();
    });
    modelBuilder.Entity<Role>(builder =>
    {
        builder.Metadata.RemoveIndex(new[] { builder.Property(r => r.NormalizedName).Metadata });
        builder.HasIndex(r => new { r.NormalizedName, r.TenantId }).HasName("RoleNameIndex").IsUnique();
    });
