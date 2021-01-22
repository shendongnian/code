    private static T InitUserCore<T>(SqlDataReader dr) where T : User, new()
    {
        T user = new T();
        // ...
        return user;
    }
    public static User InitUser(SqlDataReader dr)
    {
        return InitUserCore<User>(dr);
    }
    public static UserExtension InitUserExtension(SqlDataReader dr)
    {
        UserExtension user = InitUserCore<UserExtension>(dr);
        // ...
        return user;
    }
    
