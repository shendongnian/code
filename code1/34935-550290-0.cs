    // An abstract base class. This is what I'd use outside the 
    // Server class. It's abstract, so it can't be instantiated
    // on its own, and it only has getters for the properties. 
    public abstract class User
    {
       protected User()
       {
       }
    
       public string Name { get;}
       // Other get-only properties
    }
    
    public class ServerUser : User
    {
       public ServerUser()
       {
       }
    
       public string Name { get; set;}
       // Other properties. 
    }
