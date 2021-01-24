    public class PostViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public Comment NewComment { get; set; } // this is new addition
    }
