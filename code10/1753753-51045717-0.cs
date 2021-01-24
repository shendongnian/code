    public class Post 
    {
       public string Id {get;set;}
       public string Content {get;set;}
       public string UserId {get;set;}
    }
    
    public class Comment 
    {
      public string Id {get;set;}
      public string Content {get;set;}
      public string PostId {get;set;}
    }
    
    // this will hold data for 2 class above
    public class PostVM 
    {
      public Post Post {get;set}
      public Comment Comment {get;set}
    }
