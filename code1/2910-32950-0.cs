    class User {
        public UserRole Role{get; set;}
        public string Name {get; set;}
        public int UserId {get; set;}
    }
    public static bool IsAllowed(User user) {
        return user.Role == UserRole.LordEmperor;
    }
