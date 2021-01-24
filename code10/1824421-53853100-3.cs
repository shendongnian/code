    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         
         modelBuilder.Entity<User>().Property(u => u.UserName).HasMaxLength(30);
         modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
    }
