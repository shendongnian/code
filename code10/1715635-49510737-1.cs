    public class UserManagement
    {
        public string Test;
    
        private IUser     _user;
        private IDatabase _database;
    
        public UserManagement(IUser user, IDatabase database)
        {
          _user     = user;
          _database = database;
    
          Test = DateTime.Now.ToString();
        }
    }
