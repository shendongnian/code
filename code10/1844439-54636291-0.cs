    public class Post
    {
        [Key]
        public int Id { get; set; }
    
        public string Title { get; set; }
    
        public virtual List<PostLike> PostLikes { get; set; }
    
        public virtual List<Comment> Comments { get; set; }
    }
    
    public class Comment
    {
        [Key]
        public int Id { get; set; }
    
        public string CommentBody { get; set; }
    
        //.....
    
        public virtual List<CommentLike> CommentLikes { get; set; }
    }
    public class PostLike
    {
        [Key]
        public int Id { get; set; }
    
        public int PostId { get; set; }
    
        public bool IsLike { get; set; }
    
        public virtual Post post { get; set; }
    }
    
    public class CommentLike
    {
        [Key]
        public int Id { get; set; }
    
        public int CommentId { get; set; }
    
        public bool IsLike { get; set; }
    
        public virtual Comment Comment { get; set; }
    
    }
    
 
