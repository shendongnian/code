    public class User : IdentityUser 
    {
       public List<Relationship> UserFriends { get; set; }
       public List<Relationship> FriendUsers { get; set; }
    }
    public class Relationship {
       
       public string UserId {get; set;} // `UserId` type is string as you are using default identity
       public User User {get;set;}
    
       public string FriendId {get; set;}
       public User Friend {get;set;}
    
       // Enum of Status (Approved, Pending, Denied, Blocked)
       public RelationshipStatus RelationshipStatus {get;set;}
    
       public DateTime RelationshipCreationDate {get;set;}
    }
