    // UserName is a Read-Only property; it can't be assigned a value directly
    public static string UserName { get; private set; }
    // Anyone can change UserName here, but they have to intentionally call this method to do so
    public static void SetUserName(string userName)
    {
        UserName = userName;
    }
