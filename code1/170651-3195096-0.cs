    public interface IStore<TEntity>
    {
        event EventHandler<EntityEventArgs<TEntity>> EntityAdded;
        TEntity Get(object identifier);
        void Put(TEntity entity);
    }
    public EntityEventArgs<TEntity> : EventArgs
    {
        public TEntity Entity { get; set; }
    }
