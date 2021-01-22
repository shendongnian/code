    public class UserResult
    {
        public UserResult(User user)
        {
            Username = user.Username;
            Password = user.Password;
        }
        public string Username { get; set; }
        public string Password { get; set; }
    }
