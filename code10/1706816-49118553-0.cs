    public class Entity1
    {
        public int Id { get; set; }
        public Guid EntityKey { get; set; }
        public EntityType E1Type { get; set; }
        public ICollection<EntityMapping> Entity2s { get; set; }
    }
    public class Entity2
    {
        public int Id { get; set; }
        public Guid EntityKey { get; set; }
        public EntityType E2Type { get; set; }
        public ICollection<EntityMapping> Entity1s { get; set; }
    }
    public class EntityMapping 
    {
        public int Id { get; set; }
        public int ParentKey { get; set; }
        public int ChildKey { get; set; }
        public Entity1 Entity1 { get; set; }
        public Entity2 Entity2 { get; set; }
    }
