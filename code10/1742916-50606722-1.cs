    public interface IUser
        {
            string name { get; }
            IUser updateName(string newName);
            IUser disableUser();
        }
    
          
        public class DisabledUser : IUser
        {
            public DisabledUser(IUser activeUser)
            {
                this.name = activeUser.name;
            }
    
            public string name { get; }
            public IUser updateName(string newName)
            {
                return this;
            }
    
            public IUser disableUser()
            {
                return new DisabledUser(this);
            }
        }
    
        public class ActiveUser : IUser
        {
            public ActiveUser(IUser user)
            {
                this.name = user.name;
            }
            public string name { get; private set; }
    
            public IUser updateName(string newName)
            {
                this.name = newName;
                return this;
            }
    
            public IUser disableUser()
            {
                return new DisabledUser(this);
            }
        }
