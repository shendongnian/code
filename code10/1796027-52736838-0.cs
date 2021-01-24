    public class User : IdentityUser
    {
        public string TestA { get; set; }
    }
    public class User2 : User
    {
        public string TestB { get; set; }
    }
