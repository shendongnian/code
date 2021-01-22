    private void ExecuteInTransaction<T>(Action<T> action, T entity)
    {
        using (new Transaction())
        {
            action(entity);
        }
    }
    public void Save<T>(T entity)
    {
        ExecuteInTransaction(Session.Save, entity);
    }
