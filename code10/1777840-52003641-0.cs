    public class CurrentUserCache : ICurrentUser {
        public CurrentUserCache(IHttpContextAccessor httpContextAccessor, UserManager userManager) {
            _user = new Lazy<Task<User>>(() => 
                userManager.GetUserAsync(httpContextAccessor.HttpContext.User)
            );
        }
    
        private Lazy<Task<User>> _user;
        public Task<User> GetUserAsync() {
            return _user.Value;
        }    
    }
