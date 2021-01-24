    public class Hotel
    {
        public Hotel()
        {
            Address1 = new Address1();
        }
    
        [JsonProperty("Hotel")]
        public Address1 Address1 { get; set; }
    }
