    public class User
    {
        // ...
        public virtual ICollection<User> Friends { get; set; }
        public virtual ICollection<User> FriendOf { get; set; }
    }
    modelBuilder.Entity<User>()
       .HasMany(u => u.Friends)
       .WithMany(u => u.FriendOf);
       .Map(m => m.ToTable("UserFriends")
           .MapLeftKey("UserId")
           .MapRightKey("FriendId"));
