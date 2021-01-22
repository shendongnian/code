    class BasePlugin<TContext, TEntity> where TContext : DataContext, new()
        where TEntity : class
    {
        protected TContext DataContext = new TContext();
        protected string GetJSONData()
        {            
            return JsonConvert.SerializeObject(DataContext.GetTable<TEntity>());
        }
    }
