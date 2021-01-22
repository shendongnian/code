    public class User
      public string Name {get;set;}
      // etc
    end class
    
    public class Message
      public User Sender {get;set;}
      public string Text {get;set;}
      // etc
    end class
    public class ChatSession
      public string SessionTitle {get;set;}
      public List<User> Participants {get;set;}
      public List<Message> SentMessages {get;set;}
      public List<Message> UnsentMessages {get;set;}
    end class
