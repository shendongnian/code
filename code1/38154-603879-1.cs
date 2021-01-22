    public static Func<string, UserName> Loader {get;set;}
    
    public static Constructor()
    {
      Loader = GetFromDataBase;
    }
    
    public static User GetUser(string userName)
    {
      User user = GetUserFromCache()
      if (user == null)
      {
        user = Loader(userName);
        StoreUserInCache(user);
      }
      return user;
    }    
    
    public void Test1()
    {
      UserGetter.Loader = Mock.GetUser;
      UserGetter.GetUser("Bob");
    }
