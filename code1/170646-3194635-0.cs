    public abstract class Store<TEntity>
    {
        public abstract TEntity Get(object identifier);
        public void Put(TEntity entity)
        {
            //Do actions before call
            InternalPut(entity);
            //Raise event or other postprocessing
        }
        protected abstract void InternalPut(TEntity entity);
    }
