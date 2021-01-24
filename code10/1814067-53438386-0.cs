    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserType Type { get; set; }
        public enum UserType {
            User,
            OtherUser
        }
    }
