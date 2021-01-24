    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public List<Friend> Friends { get; set; }
        public User()
        {
              Friends = new List<Friend>();
        }
    }
    public class Friend
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UserFriend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [ForeignKey("FriendId")]
        public Friend Friend { get; set; }
    }
