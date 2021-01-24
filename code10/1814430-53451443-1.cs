    public static class Authentication
    {
        public static User CurrentUser { get; private set; }
    
        public static bool Login(User user)
        {
            if(user == null)
                throw new ArgumentException("Invalid user","user");
            CurrentUser = user;
        }
    }
