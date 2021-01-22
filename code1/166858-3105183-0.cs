    class BasePlugin<TContext, TEntity> where TContext : DataContext, new()
    {
        protected TContext DataContext = new TContext();
        protected string GetJSONData()
        {            
            return JsonConvert.SerializeObject(DataContext.GetType<TEntity>());
        }
    }
