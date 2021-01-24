    public class Photo
    {
       public int PhotoID {get; set;}
       public string Title {get; set;}
       public string Description {get; set;}
    
       private List<Comment> _comments = new List<Comment>();
       public virtual List<Comment> Comments 
       {
          get {return _comments;}
          set {_comments = value;}
       }
    }
    
    public class Comment
    {
       public string UserName {get; set;}
       public string Subject {get; set;}
    }
