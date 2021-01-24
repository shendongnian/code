    public class UserController
    {
        private IContextDb _userContext
        public UserController(UserContext userContext)
        {
           _userContext = userContext;
        }
    }
