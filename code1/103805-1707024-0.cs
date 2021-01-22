    class MyClass
    {
        private static  string user;
    
        public static string User
        {
            get { return user; }
            set { user = value; }
        }
    
    }
    
    class MyOtherClass
    {
        public string  GetUserFromMyClass()
        {
            return MyClass.User;
        }
    }
