    interface IUserData {
      User GetUser(uint id);
      User ByName(string username);
    }
    
    public class UserData : IUserData {
       public User GetUser(uint id)
       {
          //do something
       }
       public User ByName(string username)
       {
    	  //do something
       }
    }
    
    public class AuthorizedUserData : IUserData {
      IUserData _Data;
      public AuthorizedUserData(IUserData data)
      {
    	 _Data = data;
      }
      public User GetUser(uint id) {
        AuthorizationHelper.Instance.Authorize();
        return _Data.GetUser(id);
      }
    
      public User ByName(string name) {
        AuthorizationHelper.Instance.Authorize();
        return _Data.ByName(name);
      }
    }
