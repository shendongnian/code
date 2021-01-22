    public abstract class MyStoreBase : IStore<TEntity>
    {
        public abstract TEntity Get(object identifier);
        public abstract void PutImpl(TEntity entity);
        public void Put(TEntity entity)
        {
            // Each inheritor will implement this method.
            PutImpl(entity);
            // But event is fired in base class.
            FireEvent();
        }
    }
