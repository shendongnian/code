    public interface ISpecification<T>
    {
      bool IsSatisfiedBy(TEntity entity);
    }
    
    public class UniqueUsernameSpecification : ISpecification<User>
    {
      private readonly IUserRepository _userRepository;
       
      public UniqueUsernameSpecification(IUserRepository userRepository)
      {
        _userRepository = userRepository;
      }
    
      public bool IsSatisfiedBy(User user)
      {
        User foundUser = _userRepository.FindUserByUsername(user.Username);
        return foundUser == null;
      }
    }
    
    //App code    
    User newUser;
    
    // ... registration stuff...
    
    var uniqueUserSpec = new UniqueUsernameSpecification();
    if (uniqueUserSpec.IsSatisfiedBy(newUser))
    {
      // proceed
    }
