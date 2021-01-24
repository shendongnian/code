    class Guardian
    {
        [JsonProperty(PropertyName = "guardian_id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "guardian_name")]
        public string Name { get; set; }            // <-- This
    }
    class Patient
    {
        [JsonProperty(PropertyName = "patient_id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "patient_name")]
        public string Name { get; set; }            // <-- This
    }
