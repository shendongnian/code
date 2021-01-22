    public class UserList : List<User>
    {}
    
    class User 
    { 
      public int id {get; set;} 
      public bool IsManager { get; set;}
    }
    
    class Office {
        private UserList _users;
        UserList Managers
        {
            get { return (UserList) _users.FindAll(x => x.IsManager);}
        }
    }
