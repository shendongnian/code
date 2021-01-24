    class Entity
    {
        public Entity(Guid entityId)
        {
            EntityId = entityId;
            Components = new List<IComponent>();
        }
    
        public Guid EntityId { get; }
        public List<IComponent> Components { get; }
    }
