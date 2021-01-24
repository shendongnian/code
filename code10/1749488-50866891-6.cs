    public class Entity2
    {
        public bool Flag1 { get; set; }
        public bool Flag2 { get; set; }
    }
    public class Entity1
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Entity2 Metadata { get; set; }
    }
