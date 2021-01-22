    public class PostType
    {
        public int PostId { get; set; }
        public List<PostComment> PostComments { get; set; }
    }
    public class PostComment
    {
        public int CommentId { get; set; }
        public string Title { get; set; }
    }
