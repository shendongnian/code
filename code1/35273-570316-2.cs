    private ICommentRepository _commentRepo;
    
    public class Post
    {
      public Post(ICommentRepository commentRepo)
      {
        // Or you can remove this forced-injection and use a 
        // "Service Locator" to wire it up internall.
        _commentRepo = commentRepo;
      }
    
      public int PostID { get; set; }
    
      public void DeleteComments(IList<Comment> comments)
      {
        // put your logic here to "lookup what has been deleted"
        // and then call ICommentRepository.Delete() in the loop.
    
        _commentRepo.Remove(commentID);
      }
    }
