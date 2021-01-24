    [JsonConverter(typeof(ResourceCollectionConverter))]
    public class ResourceCollection {
        public string Name { get; set; }
        public Resources Resources { get; set; }
    }
