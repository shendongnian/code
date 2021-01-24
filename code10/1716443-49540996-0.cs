    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
    
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        //create the user
    }
    
    public interface IUserService : IUserStore<UserModel>, IUserLoginStore<UserModel>, IUserPasswordStore<UserModel>, IUserSecurityStampStore<UserModel>
    {
       ...
    }
