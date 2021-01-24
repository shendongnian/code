    public partial class Data
    {
        [JsonProperty("locations")]
        public Location[] Locations { get; set; }
    }
    public partial class Location
    {
        [JsonProperty("timestampMs")]
        public string TimestampMs { get; set; }
        [JsonProperty("latitudeE7")]
        public long LatitudeE7 { get; set; }
        [JsonProperty("longitudeE7")]
        public long LongitudeE7 { get; set; }
        [JsonProperty("accuracy")]
        public long Accuracy { get; set; }
    }
