    class PoolDecorator<T> : IComponentPool<T>
    {
        private readonly IComponentPool<T> wrappedPool;
        private readonly EntityManager entityManager;
        private readonly ISystem system;
    
        public PoolDecorator(IComponentPool<T> componentPool, EntityManager entityManager, ISystem system)
        {
            this.wrappedPool = componentPool;
            this.entityManager = entityManager;
            this.system = system;
        }
    
        public void AddEntity(Guid entityId, T component)
        {
            wrappedPool.AddEntity(entityId, component);
    
            if (system.ComponentTypes
                .Select(t => entityManager.GetComponentPool(t))
                .All(p => p.ContainsEntity(entityId)))
            {
                system.SystemEntities.Add(entityId);
            }
        }
    
        public void RemoveEntity(Guid entityId)
        {
            wrappedPool.RemoveEntity(entityId);
            system.SystemEntities.Remove(entityId);
        }
    
        public bool ContainsEntity(Guid entityId)
        {
            return wrappedPool.ContainsEntity(entityId);
        }
    }
