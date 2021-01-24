    modelBuilder.Entity<User>(entity =>
    {
       entity.HasKey(o => o.UserId );
       entity.Property(e => e.UserId).ValueGeneratedOnAdd().HasColumnName("user_id")
     ...................
