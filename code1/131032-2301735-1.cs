    [ServiceContract]
    public interface IMyServiceContract
    {
        [OperationContract]
        void Update(User[] users, Group[] groups);
    }
    
    public class MyService : IMyServiceContract
    {
        private readonly IUserDAO _userDao;
        private readonly IGroupDAO _groupDao;
        public MyService(IUserDAO userDao, IGroupDAO groupDao)
        {
            _userDao = userDao;
            _groupDao = groupDao;
        }
    
        public void Update(User[] users, Group[] groups)
        {
            _groupDao.UpdateGroups(groups);
            _userDao.UpdateUsers(users);
        }
    }
