    public class EntityA
    {
        public int EntityAId { get; set; }
        public virtual ICollection<DependentEntity> DependentEntity { get; set; }
    }
    public class EntityB
    {
        public int EntityBId { get; set; }
        public virtual ICollection<DependentEntity> DependentEntity { get; set; }
    }
