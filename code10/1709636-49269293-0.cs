    [JsonObject(MemberSerialization.OptIn)]
    public class Sector : RealmObject
    {
        [JsonProperty]
        public string parent_type { get; set; } 
    }
