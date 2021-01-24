    public class Multipoint
    {
        [JsonProperty(PropertyName = "points", ItemConverterType = typeof(MyPointsConverter))]
        public List<Point> Points { get; set; }
    }
