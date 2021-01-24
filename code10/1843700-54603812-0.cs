    public class Comment
    {
     [Key]
            public Guid Id { get; set; }
    
            [Required, MaxLength(1000)]
            public string Message { get; set; }
    
            [Required]
            public DateTime Created { get; set; }
    
            //need to set this up
            public ICollection<Comment> ChildComments { get; set; }
    
            [Required]
            public Guid PostId { get; set; }
    
            [Required]
            public Post CommentForPost { get; set; }
    
            [Required]
            public Guid UserId { get; set; }
    
            [Required]
            public User CreatedBy { get; set; }
    
       //this comment can be a child comment for (if is set) 
       // ParentCommentId is optional
               public string ParentCommentId {get;set;}
               public Comment ParentComment {get;set;}    
       //this comment can have many comments
               public ICollection<Comment> ChildComments {get;set;}
    
    }
