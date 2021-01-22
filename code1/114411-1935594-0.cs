    public static void DoInTransaction<T>(this T entity, Action<T> action)
    {
        using (var transaction = Session.BeginTransaction())
        {
            if (entity is IEnumerable<T>)
            {
                foreach (T item in (IEnumerable<T>) entity)
                {
                    action(item);
                }
            }
            else
            {
                action(entity);
            }
    
            transaction.Commit();
        }
    }
