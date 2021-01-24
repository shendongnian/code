    public class ShapeContainer
    {
        [JsonConverter(typeof(NoConverter))]
        public TheShape Shape { get; set; }
        [JsonProperty(ItemConverterType = typeof(NoConverter))]
        public List<TheShape> Shapes { get; set; }
    }
