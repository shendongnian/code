    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>(entity =>
        {
            entity.HasOne(u => u.UserDetail).WithOne(d => d.User);
        });
        builder.Entity<UserDetails>(entity =>
        {
            // set the UserId as key
            entity.HasKey(d=>d.UserId);
            // the relationship between `UserDetails : User`  is  1-to-1
            entity.HasOne(d=>d.User).WithOne(u=>u.UserDetail)
                // set column `UserId` as the FK for the dependent entity , i.e. , the `UserDetails` .
                .HasForeignKey<UserDetails>(u=>u.UserId); 
        });
    }
