    public void DoSomething()
    {
        User user = GetUser(x => x.ID == 12);
    }
    IQueryable<User> UserCollection;
    public User GetUser(Expression<Func<User,bool>> expression)
    {
        return UserCollection.expression;
    }
