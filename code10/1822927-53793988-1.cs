    public class Post
    {
        public int Id { get; set; }
        public Guid CurrentVersionId { get; set; }
        public PostVersion CurrentVersion { get; set; }
        public PostVersion OriginalVersion { get; set; }
        public IList<PostVersion> History { get; set; }
    }
    modelBuilder.Entity<Post>()
       .HasOne(x => x.CurrentVersion)
       .WithOne(x => x.CurrentVersion)
       .HasForeignKey<Post>(x =>x.CurrentVersionId); // 
   
