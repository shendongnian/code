    public T InsertUpdate(T obj, DB context, Func<T,bool> lambda)
    {
         var entity = context.Set<T>().SingleOrDefault(lambda);
        if (entity == null)
        {
            entity = context.Set<T>().Add(obj);
        } 
        else
        {
            context.Entry(entity).CurrentValues.SetValues(obj);
        }
        context.SaveChanges();
        return entity;
    }
