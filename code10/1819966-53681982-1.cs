    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.UserId);
        builder.Property(u => u.CreatedOn).IsRequired(true).HasDefaultValueSql("getdate()");
        // FK - configuraiton
        builder.HasOne(u => u.Role).WithMany().HasForeignKey(u => u.RoleId).IsRequired(true);
    }
