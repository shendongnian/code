    public interface IClientAvailableUser 
    {
        string Username { get; set; }
        string Password { get; set; }
    }
    
    internal class ConcreteClientAvailableUser : IClientAvailableUser 
    {
       public string UserName{get;set;}
       public string Password{get;set;}
    }
    public class UserExtensions
    {
        public IClientAvailableUser AsClientAvailableUser(this User user)
        {
            return new ConcreteClientAvailableUser { UserName = user.UserName, Password = user.Password};
        }        
    }
