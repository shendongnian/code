    public class UserHelper
    {
    
       public bool AddUser(User user)
       {
          _db.Users.Add(user);
          return _db.SaveChanges() == 1;
    
       }
       public User GetUserInfoById(User user)
       {
          User dbInfo = _db.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
    
          return dbInfo;
       }
       public bool EditUserInfoById(User user)
       {
          var results = _db.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
    
          results.Username = user.Username;
          results.Firstname = user.Firstname;
          results.Lastname = user.Lastname;
          results.Password = user.Password;
          results.Email = user.Email;
    
          _db.SaveChanges();
    
          return true;
       }
    }
