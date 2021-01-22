    [AutoMapping(typeof(Cms_Schema))]
    public class Schema : ISchema
    {
        public Int32 SchemaId { get; set; }
        public String SchemaName { get; set; }
        public Guid ApplicationId { get; set; }
    }
