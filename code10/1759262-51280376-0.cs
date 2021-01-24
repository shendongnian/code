    public class CraneSubModel
    {
        public string Name { get; set; }
        public long? MaxLoad { get; set; }
        public long? MaxSpan { get; set; }
        public long? Speed { get; set; }
    }
    
    public class CraneModel
    {
        public long? Id { get; set; }
        public long? IDType { get; set; }
        public long? IDManufacturer { get; set; }
        public CraneSubModel subModel { get; set; }
    }
