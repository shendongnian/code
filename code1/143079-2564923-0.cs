    public class User { 
     
       public string ID {get;set;} 
       public string FirstName {get; set;} 
       public string LastName {get; set;} 
       public string PhoneNo {get; set;} 
     
      public AccountCollection accounts {get; set;} 
     
      public User { 
         accounts = new AccountCollection(this); 
      } 
     
      public static List<Users> GetUsers() { 
         return Data.GetUsers(); 
      } 
     
    } 
