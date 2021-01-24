    public class UserService
    {
        private readonly IUserDatabase _userDatabase;
        public UserService(IUserDatabase userDatabase)
        {
            _userDatabase = userDatabase;
        }
        public bool DoesUserExist(int userId)
        {
            return _userDatabase.UserExists(userId);
        }
    }
