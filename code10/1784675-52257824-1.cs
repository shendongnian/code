    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
     
        [Index]
        public int Rating { get; set; }
     
        public virtual ICollection<Post> Posts { get; set; }
    }
