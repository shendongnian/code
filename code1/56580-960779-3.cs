    public virtual void Update(T entity)
    {
            var dbcontext = DB;
            dbcontext.GetTable<T>().Attach(entity, true);
            dbcontext.SubmitChanges();
    }
