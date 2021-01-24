    [JsonObject]
    public class ListRequestDto {
        public bool? WithCreator { get; set; }
        public int? Skip { get; set; }
        public int? Limit { get; set; }
    }
