    static class UserLogOn
    {
        private static string _userName = "";
        private static string _fullName = "";
        internal static string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        internal static string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
    }
