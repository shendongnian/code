    [ModelBinder(typeof(AttributeModelBinder))]
    public class PersonModel
    {
        [JsonProperty("pid")]
        public int PersonId { get; set; }
        
        public string Name { get; set; }
    }
