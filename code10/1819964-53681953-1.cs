    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.UserId);
        builder.Property(x => x.RoleId).IsRequired(true);
        builder.Property(x => x.CreatedOn).IsRequired(true).HasDefaultValue(DateTime.Now);
    
        
        builder.HasOne(x => x.Role).WithMany(y => y.Users);
    }
