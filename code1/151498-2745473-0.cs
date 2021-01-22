    public static void Main(string[] args)
    {
        int userId = 0;
        Tuple<string, string> userData = GetUserData(userId);
    }
    public static Tuple<string, string> GetUserData(int userId)
    {
        return new Tuple<string, string>("Hello", "World");
    }
