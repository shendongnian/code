    interface ITaskService
    {
        void SomeOperation();
    }
    
    interface IEntityService
    {
        Entity GetEntity(object key);
        Entity Save(Entity entity);
    }
    
    class TaskService: ITaskService
    {
        public TaskService(EntityServiceFactory factory)
        {
            m_factory = factory;
        }
    
        private EntityServiceFactory m_factory; // Dependency
    
        public void SomeOperation() // Method must be concurrent, so create new IEntityService each call
        {
            IEntityService entitySvc = m_factory.GetEntityService();
            Entity entity = entitySvc.GetEntity(...);
            // Do some work with entity
            entitySvc.Save(entity);
        }
    }
    
    class EntityServiceFactory
    {
        public EntityServiceFactory(RepositoryProvider provider)
        {
            m_provider = provider;
        }
    
        private RepositoryProvider m_provider; // Dependency
    
        public virtual IEntityService GetEntityService()
        {
            var repository = m_provider.GetRepository<Entity>();
            return new EntityService(repository);
        }
    }
    
    class EntityService: IEntityService
    {
        public EntityService(IEntityRepository repository)
        {
            m_repository = repository;
        }
    
        private IEntityRepository m_repository; // Dependency
    
        public Entity GetEntity(object key)
        {
            if (key == null) throw new ArgumentNullException("key");
    
            // TODO: Check for cached entity here?
    
            Entity entity = m_repository.GetByKey(key);
            return entity;
        }
    
        public Entity Save(Entity entity)
        {
            if (entity == null) throw new ArgumentNullException(entity);
    
            if (entity.Key == null)
            {
                entity = m_repository.Insert(entity);
            }
            else
            {
                m_repository.Update(entity);
            }
    
            return entity;
        }
    }
    class RepositoryProvider
    {
        public virtual object GetRepository<T>()
        {
            if (typeof(T) == typeof(Entity))
                return new EntityRepository();
            else if (...)
                // ... etc.
        }
    }
    
    interface IEntityRepository
    {
        Entity GetByKey(object key);
        Entity Insert(Entity entity);
        void Update(Entity entity);
    }
    
    class EntityRepository: IEntityRepository
    {
        public Entity GetByKey(object key)
        {
            // TODO: Load up an entity from a database here
        }
    
        public Entity Insert(Entity entity)
        {
            // TODO: Insert entity into database here
        }
    
        public void Update(Entity entity)
        {
            // TODO: Update existing entity in database here
        }
    }
