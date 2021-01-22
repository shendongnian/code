    public void Action(Action<IDataContext> getDataContext, Action<IUserRepository> getUserRepository)
    {
        using(IDataContext dc = getDataContext())
        {
            IUserRepository repo = getUserRepository();
            // Do stuff with repo...
        }
    }
