    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<Relationship>().HasKey(r => new {r.UserId, r.FriendId});
        modelBuilder.Entity<Relationship>()
        .HasOne(r => r.User)
        .WithMany(u => u.UserFriends)
        .HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);
    
        modelBuilder.Entity<Relationship>()
        .HasOne(r => r.Friend)
        .WithMany(f => f.FriendUsers)
        .HasForeignKey(r => r.FriendId).OnDelete(DeleteBehavior.Restrict);
    }
