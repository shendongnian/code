    void Main()
    {
    	var json = "Your JSON string here...";
    	
    	var response = JsonConvert.DeserializeObject<Response>(json);
    	var allPrizeIds = response.Body.Where(b => b.PrizeIds != null)
                                       .SelectMany(b => b.PrizeIds);
    	
        var matchingPrizes = allPrizeIds.Where(p => p == "przv3d75ezcrqf1xy6b");
    	allPrizeIds.Dump();
    }
    
    public class Response
    {
    	[JsonProperty("body")]
    	public List<Body> Body { get; set; }
    }
    
    public class Body
    {
    	[JsonProperty("prize_ids")]
    	public List<string> PrizeIds { get; set; }
    }
