    internal class DynamicModelCacheKeyFactory : IModelCacheKeyFactory
    {
        public object Create(DbContext context)
        {
            if (context is SqlContext dynamicContext)
            {
                return (context.GetType(), dynamicContext._roleCategory);
            }
            return context.GetType();
        }
    }
