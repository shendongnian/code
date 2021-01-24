    class PlayerDetails
    {
    	public string AbilityID { get; set; }
    	public string Value { get; set; }
    }
    
    class Player
    {
    	public string PlayerID { get; set; }
    	public List<PlayerDetails> Details { get; set; }
    }
