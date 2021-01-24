    public class UserRepository: IUserRepository {
        private readonly IHeaderService headerService;
        public UserRepository(IHeaderService headerService) { 
            this.headerService = headerService;
        }
    
        public UserInformation GetUserInfo() {
            var headerValue = headerService.RealHeaderValueFromHttpRequest();
            var _userInfo = LoadUserData(headerValue);
            return _userInfo;
        }
        //...
    }
