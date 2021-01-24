    [JsonObject(IsReference = true)]
    public abstract class ModelBase : IModelBase
    {
        public string ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
