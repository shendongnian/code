    private void DatabaseAction<T>(T entity, Action<T> action) 
    {
        using (var transaction = Session.BeginTransaction())
        {
            if (entity is IEnumerable)
            {
                foreach (var item in (IEnumerable) entity)
                {
                    action(item);
                }
            }
            else
            {
                action(item);
            }
        
            transaction.Commit();
        }
    }
