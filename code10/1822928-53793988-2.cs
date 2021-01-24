     public class Post
    {
        public int Id { get; set; }
        public Guid CurrentVersionId { get; set; }
        public PostVersion CurrentVersion { get; set; }
        public Guid OriginalVersionId { get; set; }
        public PostVersion OriginalVersion { get; set; }
        public IList<PostVersion> History { get; set; }
    }
    public class PostVersion
    {
        public int Id { get; set; }
        public Post Post{ get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
    modelBuilder.Entity<Post>()
                .HasOne(x => x.CurrentVersion)
                .WithOne(x => x.Post)
                .HasForeignKey<Post>(x => x.CurrentVersionId);
            modelBuilder.Entity<Post>()
                .HasOne(x => x.OriginalVersion)
                .WithOne(x => x.Post)
                .HasForeignKey<Post>(x => x.OriginalVersionId);
            modelBuilder.Entity<Post>()
                .HasMany(x => x.History)
                .WithOne(x => x.Post); 
   
