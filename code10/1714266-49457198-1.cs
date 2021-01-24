    public class ModelBaseCollectionDTO
    {
        [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
        public List<ModelBase> Models { get; set; }
    }
