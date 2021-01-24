    [JsonObject(MemberSerialization.OptIn)]
    public class Address
    {
        [JsonProperty]
        private string _field1 = "bob";
        public string Line1 { get; set; }
    
        public string Line2 { get; set; }
    
        public string Line3 { get; set; }
    }
