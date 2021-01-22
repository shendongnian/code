    public class User
    {
        private String userName;
        [TooManyArgs] // Will show warning: Try removing some arguments
        public User(String userName)
        {
            this.userName = userName;   
        }
        public String UserName
        {
            get { return userName; }
        }
        [MustRefactor] // will show warning: Refactor is needed Here
        public override string ToString()
        {
            return "User: " + userName;
        }
    }
    [Obsolete("Refactor is needed Here")]
    public class MustRefactor : System.Attribute
    {
    }
    [Obsolete("Try removing some arguments")]
    public class TooManyArgs : System.Attribute
    {
    }
