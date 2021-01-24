    public class User
    {
        public User() { }
        public User(UserDetails user)
        {
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.Email = user.Email;
        }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    public class UserDetails : User
    {
        public string PasswordHash { get; set; }
    }
