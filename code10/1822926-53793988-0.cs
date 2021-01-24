    class PostVersion
    {
        public int Id { get; set; }
        public Guid CurrentVersionId { get; set; }
        public Post CurrentVersion { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
     builder.Entity<Post>()
        .HasOne(x => x.CurrentVersion)
        .WithOne(x => x.Post);
        .HasForeignKey(x => x.CurrentVersionId); // 
   
