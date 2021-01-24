    namespace foo
    {
      public class User
      {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<UsersFriendship> UsersFriendships { get; set; }
      }
      public class Friendship
      {
          public User User1 { get; set; }
          public int User1Id { get; set; }
          public User User2 { get; set; }
          public int User2Id { get; set; }
          public int Status  { get; set; }
      }
      class MyContext : DbContext
      {
          public DbSet<Friendship> Friendships { get; set; }
          public DbSet<User> Users { get; set; }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Friendship>()
                  .HasKey(fs => new { fs.User1, fs.User2, fs.Status });
              modelBuilder.Entity<Friendship>()
                  .HasOne(fs => fs.User1)
                  .WithMany(u => u.UsersFriendships)
                  .HasForeignKey(fs => fs.User1);
              modelBuilder.Entity<Friendship>()
                  .HasOne(fs => fs.User2)
                  .WithMany(u => u.UsersFriendships)
                  .HasForeignKey(fs => fs.User2);
          }
      }
