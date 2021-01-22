     public class UserRepository
        {
            Context context = new Context();       
            public User GetByUsernameAndPassword(User user)
            {
                return context.Users.Where(u => u.Username==user.Username & u.Password==user.Password).FirstOrDefault();
            }
        }
