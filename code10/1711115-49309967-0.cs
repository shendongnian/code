    private IHttpActionResult GetData<TEntity>() where TEntity : class
    {
        using (var context = new YourContext())
        {
            var dbSet = context.Set<TEntity>();
        }
    }
