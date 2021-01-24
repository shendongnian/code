     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<AVUser>().HasOne(a => a.SelectedToy).WithOne();
          modelBuilder.Entity<AVUser>().HasMany(a => a.Toys).WithOne(t => t.AVUser).HasForeignKey(t => t.UserId);
     }
