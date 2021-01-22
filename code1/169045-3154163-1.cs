    public void Action(Func<IDataContext> getDataContext, Func<IUserRepository> getUserRepository)
    {
        using(IDataContext dc = getDataContext())
        {
            IUserRepository repo = getUserRepository();
            // Do stuff with repo...
        }
    }
