    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<RolePermission>().HasKey(table => new {
            table.RoleId,
            table.PermissionId
        });
    }
