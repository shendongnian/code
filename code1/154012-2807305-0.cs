    public class User : ICanValidate {
        public User() {} 
    
        public virtual string Username { get; set; }
    
        public IEnumerable<ValidationError> Validate() {
            if (!string.IsNullOrEmpty(this.UserName))
              yield return new ValidationError("Username must not be empty");
        }
    }
    
    public class UserRepository : IUserRepository {
    }
    
    public static class UserService { 
      readonly IUserRepository Repository;
      
      static UserService() {
        this.Repository = ServiceLocator.GetService<IUserRepository>();
      }
    
      public static IEnumerable<ValidationError> Validate(User user) {
          if (Repository.FindUserByUsername(user.Username) != null)
              yield return new ValidationError("Username", "User already exists.")
      }
    }
