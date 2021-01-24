    public class Question
    {
        public int Id {get; set;}
        // every Question has zero or more Upvotes:
        public virtual ICollection<Upvote> Upvotes {get; set;}
  
        public string QuestionText {get; set;}
        ... // other properties and relations
    }
    public class Upvote
    {
        public int Id {get; set;}
        // every Upvote belongs to exactly one Question using foreign key:
        public int QuestionId {get; set;}
        public virtual Question Question {get; set;}
        // every Upvote was done by exactly one User using foreign key:
        public int UserId {get; set;}
        public virtual User User {get; set;}
        
        ... // other properties and relations
    }
    public class User
    {
        public int Id {get; set;}
        // every User has zero or more Upvotes:
        public virtual ICollection<Upvote> Upvotes {get; set;}
        ... // other properties and relations
    }
