    public class UserBase {
        public string Name { get; set; }
        public string Email { get; set; }
    }
     
    public class User : UserBase {
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
    }
    
    var user = new User() {
        UserId = "Secret",
        PasswordHash = "Secret",
        Name = "Me",
        Email = "something"
    };
     
    var serialized = JsonConvert.SerializeObject((UserBase) user);
