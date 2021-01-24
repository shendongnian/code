    public static class Authentication
    {
        public static User CurrentUser { get; private set; }
    
        public static bool Login(string userName, string password)
        {
            var user = Match(userName,password);
            if(user != null)
            {
                currentUser = user;
                return true;
            }
            else
                return false;
        }
    }
