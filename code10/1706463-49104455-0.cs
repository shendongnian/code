    public class EntityA
    {
        public int EntityAId { get; set; }
        public DependentEntity DependentEntity { get; set;}
    }
    
    public class EntityB
    {
        public int EntityBId { get; set; }
        public DependentEntity DependentEntity { get; set;}
    }
    
    public class DependentEntity
    {
        public int DependentEntityId { get; set; }
        public ...etc..etc
    }
