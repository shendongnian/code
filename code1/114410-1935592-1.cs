    public void Add<T>(T entity)
    {
        DatabaseAction(entity, item => Session.Save(item));
    }
    public void Update<T>(T entity)
    {
        DatabaseAction(entity, item => Session.Update(item));
    }
    public void Delete<T>(T entity)
    {
        DatabaseAction(entity, item => Session.Delete(item));
    }
