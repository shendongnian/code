    public class DependentEntity
    {
        public int DependentEntityId { get; set; }
        public Nullable<int> EntityAOrBId { get; set; }
        public string EntityType { get; set; }
    }
