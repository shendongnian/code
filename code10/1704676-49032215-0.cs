    public class UserService
    {
        private readonly IUserServiceContext _userServiceContext;
        public UserService(IUserServiceContext userServiceContext)
        {
            _userServiceContext = userServiceContext;
        }
