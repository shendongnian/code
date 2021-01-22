    private static void InitUser(User user, SqlDataReader dr)
    { // could also use an interface here, or generics with T : User
      user.Name = Convert.ToString(dr["name"]);
      user.Age ...
    }
    public static User InitUser(SqlDataReader dr)
    {
        User user = new User();
        InitUser(user, dr);
        return user;
    }
    public static UserExtension InitUserExtension(SqlDataReader dr)
    {
      UserExtension user = new UserExtension();
      InitUser(user, dr);
      user.Lastname = Convert.ToString(dr["lastname"]);
      user.Password = ....;
      return user;
    }
