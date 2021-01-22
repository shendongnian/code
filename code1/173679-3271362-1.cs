    public class User {
      public string Name {get;set;}
      // Sessions this user is participating in
      // (when you add to Session, add here too - Using a method to add both at same would be safest)
      public List<Session> Sessions {get;set;}
      // etc
    }
    
    public class Message {
      public User Sender {get;set;}
      public string Text {get;set;}
      // etc
    }
    public class Session {
      public string Title {get;set;}
      public List<User> Participants {get;set;}
      public List<Message> SentMessages {get;set;}
      public List<Message> UnsentMessages {get;set;}
    }
    public class ChatSystem {
       // All Users - Indexed by Name
       public Dictionary<string, User> Users {get; set;}
       // All Sessions - Indexed by Title
       public Dictionary<string, Session> Sessions {get; set;}
    }
