    public class UserApplicationServiceTests : ApplicationTestBase
    {
        private readonly IUserAppService _userAppService;
        public UserApplicationServiceTests()
        {
            var userRepository = new Repository<User>(KodkodInMemoryContext);
            _userAppService = new UserAppService(userRepository, Mapper);
        }
    ...
