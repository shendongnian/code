    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Entity<Event>().HasRequired(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);
         modelBuilder.Entity<User>()
                .HasMany<Event>(s => s.AttendingEvents)
                .WithMany(c => c.AttendingList)
                .Map(cs =>
                {
                    cs.MapLeftKey("UserId");
                    cs.MapRightKey("EventId");
                    cs.ToTable("UserEvents");
                });
    }
