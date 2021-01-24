    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
   
    }
    
    public class Tag
    {
        public string TagId { get; set; }
    }
    
    public class PostTag
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
    
        public string TagId { get; set; }
        public Tag Tag { get; set; }
    }
