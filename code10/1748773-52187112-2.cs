    public class MyDbContext: DbContext
    {
        private readonly Func<UserInfo> _userInfoFactory;
        private UserInfo UserInfo => _userInfoFactory();
        public MyDbContext(DbContextOptions options, Func<UserInfo> userInfoFactory) : base(options) 
        {
            this._userInfoFactory = userInfoFactory;
        }
        public void SomeMethod()
        {
            var someEntity = new SomeEntity()
            {
               ChangedByUserId = this.UserInfo.Id
               ...
            }
         }  
    }
