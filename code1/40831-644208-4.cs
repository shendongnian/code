    public class UserIDObject
    {
       public string ToXML() {}
    }
    public class User
    {
       private UserIDObject _userID;
    
       public UserIDObject UserID
       {
          get { return _userID; }
          set { _userID = value; }
       }
    }
    User u = new User();
    u.UserID = = new UserIDObject("Mike");
    string xml = u.UserID.ToXml();
