    public class Post
    {
        public Guid Id { get; set; }
        public PostVersion CurrentVersion { get; set; }
        public PostVersion OriginalVersion { get; set; }
        public IList<PostVersion> History { get; set; }
    }
    public class PostVersion
    {
        public Guid Id { get; set; }
        public Post Post { get; set; }
        public Post SecondPost { get; set; }
        public Post ThirdPost { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
     modelBuilder.Entity<Post>()
                .HasOne(x => x.CurrentVersion)
                .WithOne(x => x.Post);
            modelBuilder.Entity<Post>()
                .HasOne(x => x.OriginalVersion)
                .WithOne(x => x.SecondPost);
            modelBuilder.Entity<Post>()
                .HasMany(x => x.History)
                .WithOne(x => x.ThirdPost);
   
