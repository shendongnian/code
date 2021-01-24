    public class EntityAttribute
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int EntityId { get; set; }
        ...
    }
    public class Material : EntityAttribute
    {
        public int Id { get; set; }
        ...
    }
    public class Formula : EntityAttribute
    {
        public int Id { get; set; }
        ...
    }
