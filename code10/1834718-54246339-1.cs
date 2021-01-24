    public class Results
    {
     
    	public string id { get; set; }
    	[JsonIgnore]
        public Dictionary<int,Hotels> HotelDictionary { get; set; }
        [JsonProperty("hotels")]
    	public IEnumerable<Hotels> Hotels => HotelDictionary.Select(x=>x.Value);
    }
    
    public class Hotels
    {
    	[JsonProperty("hotel_id")]
    	public int Id{get;set;}
    	[JsonProperty("name")]
    	public string Name{get;set;}
    }
