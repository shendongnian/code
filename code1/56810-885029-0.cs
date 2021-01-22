    User.cs
    
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    
        public User(int userID)
        {
            //data connection
            //get records
            this.Username = datarecord["username"];
            this.Password = datarecord["password"];
        }
    }
