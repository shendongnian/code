    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    	modelBuilder.Entity<UserRole>().Property(u => u.User).HasField("_user");
    	modelBuilder.Entity<UserRole>().Property(u => u.Role).HasField("_role");
    }
