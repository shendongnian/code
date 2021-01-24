    public partial class RootObject {
        [JsonProperty("cast")]
        public Cast[] Cast { get; set; }
        [JsonProperty("crew")]
        public Crew[] Crew { get; set; }
        [JsonProperty("guest_stars")]
        public Cast[] GuestStars { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
    }
    public partial class Cast {
        [JsonProperty("character")]
        public string Character { get; set; }
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }
        [JsonProperty("gender")]
        public long Gender { get; set; }
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("order")]
        public long Order { get; set; }
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
    public partial class Crew {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("credit_id")]
        public string CreditId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("department")]
        public string Department { get; set; }
        [JsonProperty("job")]
        public string Job { get; set; }
        [JsonProperty("gender")]
        public long Gender { get; set; }
        [JsonProperty("profile_path")]
        public string ProfilePath { get; set; }
    }
