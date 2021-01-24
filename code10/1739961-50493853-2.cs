    public class DataService : ServiceBase, IDataService
    {
        public DataService(IMapper mapper) : base(mapper) { }
        public IList<UserDto> GetUsers(bool runSafeMode = true)
        {
            Func<IList<UserDto>> action = () =>
            {
                return GetUsers(_ => true);
            };
            return ExecutorHandler(action, runSafeMode);
        }
        ...
        private IList<UserDto> GetUsers(Expression<Func<User, bool>> predicate, bool runSafeMode = true)
        {
            Func<IList<UserDto>> action = () =>
            {
                using (var ymse = YMSEntities.Create())
                {
                    var users = ymse.User
                        .Include(u => u.UserUserProfile)
                        .Include(m => m.UserUserProfile.Select(uup => uup.UserProfile))
                        .Include(m => m.UserUserProfile.Select(uup => uup.User))
                        .Include(m => m.UserUserProfile.Select(uup => uup.UserProfile.UserProfileModule))
                        .Where(predicate).OrderBy(u => u.UserName).ToList();
                    return MappingEngine.Map<IList<UserDto>>(users);
                }
            };
            return ExecutorHandler(action, runSafeMode);
        }
    }
