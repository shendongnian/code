    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Relationship>()
        .HasOne(r => r.User)
        .WithMany(u => u.UserFriends)
        .HasForeignKey(r => r.UserId);
    
        modelBuilder.Entity<Relationship>()
        .HasOne(r => r.Friend)
        .WithMany(f => f.FriendUsers)
        .HasForeignKey(r => r.FriendId);
    }
