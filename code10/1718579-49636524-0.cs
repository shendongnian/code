    public class User
    {
        // I changed this to UserId to keep with naming conventions, 
        // it should otherwise be just Id, but not IdUser
        public int UserId { get; set; } 
        public int? PartnerId { get; set; }
        public User Partner { get; set; }
        public ICollection<User> Partners { get; set; }
    }
