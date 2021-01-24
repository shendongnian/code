    [Table("Comment")]
    public class Comment
    {
    	public int CommentID { get; set; }
        public List<Like> Likes { get; set; }
    }
    
    [Table("User")]
    public class User
    {
    	public int UserId { get; set; }
        public List<Like> Likes { get; set; }
    }
    
    [Table("Like")]
    public class Like
    {
    	[Key]
    	[Column(Order = 1)]
    	public int CommentID { get; set; }
    	[Key]
    	[Column(Order = 2)]
    	public int UserID { get; set; }
    
    	[ForeignKey("CommentId")]
    	public Comment Comment { get; set; }
    	[ForeignKey("UserId")]
    	public User User { get; set; }
    }
