    namespace MyProject.Configurations
    {
        public class AppUser : IAppUser
        {
            private IHttpContextAccessor httpContextProvider;
    
            public AppUser(IHttpContextAccessor _httpContextProvider)
            {
                httpContextProvider = _httpContextProvider;
            }
    
            public UserDto UserEntity
            {
                get
                {
                    return httpContextProvider.HttpContext.Session.Get<UserDto>(Constants.USER_ENTITY);
                }
            }
    	}
    }
