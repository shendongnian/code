    public class User
    {
        public int id;
        public string userName;
        public string password;
        public string role;
        private User() { }
        public static User CreateByCredentials(string uid, string pwd)
        {
            User user = new User();
            user.userName = uid;
            user.password = pwd;
            return user;
        }
        public static User CreateById(int id)
        {
            User user = new User();
            user.id = id;
            return user;
        }
          
    }
