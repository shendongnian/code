        public interface IUserData
        {
            User GetUser(uint id);
            User ByName(string username);
        }
        public class UserData : IUserData
        {
            public User GetUser(uint id)
            {
                throw new System.NotImplementedException();
            }
            public User ByName(string username)
            {
                throw new System.NotImplementedException();
            }
        }
        public class User
        {
        }
