    public class Post
    {
        public Guid Id { get; set; }
        public Guid CurrentVersionId { get; set; }
        public PostVersion CurrentVersion { get; set; }
        public Guid OriginalVersionId { get; set; }
        public PostVersion OriginalVersion { get; set; }
        public IList<PostVersion> History { get; set; }
    }
    public class PostVersion
    {
        public Guid Id { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    modelBuilder.Entity<Post>()
        .HasOne(x => x.CurrentVersion)
        .WithOne()
        .HasForeignKey<Post>(p => p.CurrentVersionId);
    modelBuilder.Entity<Post>()
        .HasOne(x => x.OriginalVersion)
        .WithOne()
        .HasForeignKey<Post>(p => p.OriginalVersionId);
    modelBuilder.Entity<Post>()
        .HasMany(x => x.History)
        .WithOne(p => p.Post)
        .HasForeignKey(pv => pv.PostId);
