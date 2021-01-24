    public partial class Time
    {
        [JsonProperty("$date")]
        public long Date { get; set; }
    }
    
    public partial class ReturnValue
    {
        [JsonProperty("facility")]
        public string Facility { get; set; }
    
        [JsonProperty("recrd_desc")]
        public string RecrdDesc { get; set; }
    
        [JsonProperty("update_time")]
        public Time UpdateTime { get; set; }  
    
        //Other properties
    }
