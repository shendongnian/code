    public class EntityAOrB
    {
        public int EntityAOrBId { get; set; }
        public virtual ICollection<DependentEntity> DependentEntity { get; set; }
        public string EntityType { get; set; }
    }
    public class DependentEntity
    {
        public int DependentEntityId { get; set; }
        public Nullable<int> EntityAOrBId { get; set; }
    }
