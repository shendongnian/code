    public abstract class AbstractStore<TEntity>
    {
        public TEntity Get(object identifier);
        public sealed void Put(TEntity entity)
        {
            if (DoPut(entity))
            {
                // raise event
            }
        }
    
        protected abstract bool DoPut(TEntity entity);
    }
