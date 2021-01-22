    public void Update(TEntity entity, TEntity original)
    {
        using (DataContext context = CreateContext())
        {
            Table<TEntity> table = context.GetTable<TEntity>();
    
            table.Attach(entity, original);
            context.SubmitChanges();
        }
    }
