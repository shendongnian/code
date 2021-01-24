    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
          base.OnModelCreating(modelBuilder);
          modelBuilder.Entity<YourEntity>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
          modelBuilder.Entity<User>().HasData(
                new User() { Id  = Guid.NewGuid(), Email = "Mubeen@gmail.com", Name = "Mubeen", Password = "123123" },
                new User() { Id = Guid.NewGuid(), Email = "Tahir@gmail.com", Name = "Tahir", Password = "321321" },
                new User() { Id = Guid.NewGuid(),  Email = "Cheema@gmail.com", Name = "Cheema", Password = "123321" }
                );
     }
