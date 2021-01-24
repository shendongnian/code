    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserBook>()
            .HasKey(ub => new { ub.UserId, ub.BookId });
        modelBuilder.Entity<UserBook>()
            .HasOne(ub => ub.ApplicationUser)
            .WithMany(au => au.UserBooks)
            .HasForeignKey(ub => ub.UserId);
        modelBuilder.Entity<UserBook>()
            .HasOne(ub => ub.Book)
            .WithMany() // If you add `public ICollection<UserBook> UserBooks { get; set; }` navigation property to Book model class then replace `.WithMany()` with `.WithMany(b => b.UserBooks)`
            .HasForeignKey(ub => ub.BookId);
    }
