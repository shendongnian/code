    public abstract class BaseEntity
    {
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
    
    public abstract class BaseEntity<TId> : BaseEntity
    {
        public virtual TId Id { get; protected set; }
    
        protected BaseEntity(TId id)
        {
            Id = id;
        }
    
        // EF requires an empty constructor
        protected BaseEntity()
        {
        }
    }
