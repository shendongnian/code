    //...
    public TableView(DataContext dataContext, Expression<Func<TEntity, bool>> predicate)
    {
        this.table = dataContext.GetTable<TEntity>();
        this.baseQuery = table.Where(predicate);
        this.predicate = predicate.Compile();
    }
    //...
