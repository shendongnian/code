    public class UserApplication
        {
            UserRepository userRepo = new UserRepository();     
            public User GetByUsernameAndPassword(User user)
            {
                return userRepo.GetByUsernameAndPassword(user);
            }
        }
